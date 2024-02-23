using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using sybring_personal.Data;
using sybring_personal.Data.Migrations;
using sybring_personal.Models;
using sybring_personal.Repos.Interface;

namespace sybring_personal.Repos.Services
{
    public class UserServices : IUserServices
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;

        public UserServices(ApplicationDbContext db, 
            UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task AddUsersAsync(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        public Task<List<User>> GetUsersAsync(List<string> email)
        {
            return _db.Users.Where(u => email.Contains(u.Email)).ToListAsync();
        }

        public async Task<List<string>> GetEmailListAsync()
        {
            return await _db.Users.Select(u => u.Email).ToListAsync();
        }

        public async Task<List<User>> GetRegisteredUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }
    }
}
