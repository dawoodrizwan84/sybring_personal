using sybring_personal.Models;

namespace sybring_personal.Repos.Interface
{
    public interface IUserServices
    {
        Task<List<User>> GetUsersAsync(List<string> email);
        Task<List<string>> GetEmailListAsync();
        Task AddUsersAsync(User user);

        Task<List<User>> GetRegisteredUsersAsync();
    }
}
