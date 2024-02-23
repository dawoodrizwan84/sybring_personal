using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using sybring_personal.Data;
using sybring_personal.Models;
using sybring_personal.Repos.Interface;
using sybring_personal.Repos.Services;

namespace sybring_personal.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<User> _userManager;

        public UserController(IUserServices userServices, ApplicationDbContext applicationDbContext,
            UserManager<User> userManager)
        {
            _applicationDbContext = applicationDbContext;
            _userServices = userServices;
            _userManager = userManager;
        }
        [Route("ui")]
        public async Task<IActionResult> Index()
        {
            var emailList = await _userServices.GetEmailListAsync();
            var users = await _userServices.GetUsersAsync(emailList);
            return View(users);
        }

        [Route("uc")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Route("uc")]
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                await _userServices.AddUsersAsync(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [Route("ur")]
        public async Task<IActionResult> UsersList()
        {
            var registeredUsers = await _userServices.GetRegisteredUsersAsync();
            return View(registeredUsers);
        }
    }
}
