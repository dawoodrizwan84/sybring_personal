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


        public async Task<IActionResult> Edit(int id)
        {
            var consultant = await _consultantServicves.GetConsultantByIdAsync(id);

            if (consultant == null)
            {
                return NotFound();
            }

            var projects = await _consultantServicves.GetProjects();

            var consultantVM = new ConsultantVM
            {
                Id = consultant.Id,
                Name = consultant.Name,
                Address = consultant.Address,
                Price = consultant.Price,
                Description = consultant.Description,
                ProjectId = consultant.ProjectId,
                ChosenProject = consultant.ProjectId, // Assuming you want to pre-select the existing project
                UserProjects = projects.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name,
                    Selected = p.Id == consultant.ProjectId // Pre-select the existing project in the dropdown
                }).ToList()
            };

            return View(consultantVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ConsultantVM consultantVM)
        {
            if (ModelState.IsValid)
            {
                var success = await _consultantServicves.UpdateConsultantAsync(consultantVM);

                if (success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to update consultant. Please try again.");
                }
            }

            // If ModelState is not valid or if the update was not successful, return to the Edit view with the model.
            var projects = await _consultantServicves.GetProjects();
            consultantVM.UserProjects = projects.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name,
                Selected = p.Id == consultantVM.ChosenProject
            }).ToList();

            return View(consultantVM);
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
