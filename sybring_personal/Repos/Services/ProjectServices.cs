using Microsoft.EntityFrameworkCore;
using sybring_personal.Data;
using sybring_personal.Models;
using sybring_personal.Repos.Interface;

namespace sybring_personal.Repos.Services
{
     public class ProjectServices : IProjectServices
    {
        private readonly ApplicationDbContext _db;


        public ProjectServices(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddProjectAsync(Project project)
        {
            _db.Projects.Add(project);
            await _db.SaveChangesAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _db.Projects.FindAsync(id); 
        }

        public async Task<List<Project>> GetProjectsAsync()
        {
            return await _db.Projects.ToListAsync(); 
        }
    }
}
