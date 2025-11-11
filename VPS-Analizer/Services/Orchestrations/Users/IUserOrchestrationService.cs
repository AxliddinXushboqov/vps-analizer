using VPS_Analizer.Models.Clients;
using VPS_Analizer.Models.Users;

namespace VPS_Analizer.Services.Orchestrations.Users
{
    public interface IUserOrchestrationService
    {
        ValueTask<User> AddUserAsync(User user);
        IQueryable<User> GetAllUsers();
        ValueTask<User> UpdateUserSourceAsync(Client client);
        ValueTask<User> UpdateUserAsync(User user);
        ValueTask<User> DeleteUserAsync(string VpsId);
    }
}
