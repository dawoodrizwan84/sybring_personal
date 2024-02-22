using sybring_personal.Models;
using sybring_personal.Models.ViewModels;

namespace sybring_personal.Repos.Interface
{
    public interface IConsultantServicves
    {
        Task<List<Consultant>> GetConsultantsAsync();

        Task AddConsultant(ConsultantVM consultantVM, string userId);

        Task<bool> UpdateConsultantAsync(ConsultantVM consultantVM);

        Task<bool> DeleteConsultantAsync(int id);

        Task<Consultant> GetConsultantByIdAsync(int id);

        Task<List<Project>> GetProjects();
    }
}
