using sybring_personal.Models;

namespace sybring_personal.Repos.Interface
{
    public interface IProjectServices
    {
        Task<List<Project>> GetProjectsAsync(); 

        Task AddProjectAsync(Project project); 
        Task<Project> GetProjectByIdAsync(int id); 
    }
}
