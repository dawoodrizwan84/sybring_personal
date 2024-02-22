using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using sybring_personal.Data;
using sybring_personal.Models;
using sybring_personal.Repos.Interface;

namespace sybring_personal.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectServices _projectServices;
        private readonly ApplicationDbContext _applicationDbContext;


        public ProjectController(IProjectServices projectServices, 
            ApplicationDbContext applicationDbContext)

        {
            _applicationDbContext = applicationDbContext;
            _projectServices = projectServices;
        }

        [Route("index")]
        public async Task<IActionResult> Index()
        {
            var projects = await _projectServices.GetProjectsAsync();
            return View(projects);
        }

        public async Task<IActionResult> Details(int id)
        {
            var project = await _projectServices.GetProjectByIdAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Project project)
        {
            if (ModelState.IsValid)
            {
                await _projectServices.AddProjectAsync(project);
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }
    }
}
