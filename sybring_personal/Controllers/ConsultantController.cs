using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using sybring_personal.Data;
using sybring_personal.Models;
using sybring_personal.Models.ViewModels;
using sybring_personal.Repos.Interface;
using sybring_personal.Repos.Services;

namespace sybring_personal.Controllers
{
    public class ConsultantController : Controller
    {
        private readonly IConsultantServicves _consultantServicves;
        private readonly ApplicationDbContext _applicationDbContext;
        private UserManager<User> _userManager;

        public ConsultantController(IConsultantServicves consultantServicves,
            ApplicationDbContext applicationDbContext, UserManager<User> userManager)
        {
            _applicationDbContext = applicationDbContext;
            _consultantServicves = consultantServicves;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _consultantServicves.GetConsultantsAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            ConsultantVM consProj = new ConsultantVM();

            var projList = await _consultantServicves.GetProjects();

            foreach (var item in projList)
            {
                consProj.UserProjects.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name


                });
            }
            return View(consProj);
        }

        [HttpPost]

        public async Task<IActionResult> Create(ConsultantVM consultantVM) 
        {
            var userId = _userManager.GetUserId(User);
            await _consultantServicves.AddConsultant(consultantVM, userId);
            return RedirectToAction("Index");
        }

       
        public async Task<IActionResult> Edit(ConsultantVM consultantVM) 
        {
            var editCons = await _consultantServicves.UpdateConsultantAsync(consultantVM);
            if (editCons)
            {
                return RedirectToAction("Index");
            }
            return View(editCons);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _consultantServicves.DeleteConsultantAsync(id);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Details(int id)
        {
            var detail = await _consultantServicves.GetConsultantByIdAsync(id);
            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }
    }
}
