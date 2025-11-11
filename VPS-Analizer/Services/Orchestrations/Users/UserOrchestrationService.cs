using MeneMarket.Services.Foundations.Users;
using VPS_Analizer.Models.Clients;
using VPS_Analizer.Models.Users;

namespace VPS_Analizer.Services.Orchestrations.Users
{
    public class UserOrchestrationService : IUserOrchestrationService
    {
        private readonly IUserService userService;

        public UserOrchestrationService(IUserService userService) =>
            this.userService = userService;

        public async ValueTask<User> AddUserAsync(User user)
        {
            IQueryable<User> users = this.userService.RetrieveAllUsers();

            User? existingUser = users
                .Where(u => u.ClientLogin == user.ClientLogin || u.VpsId == user.VpsId)
                .FirstOrDefault();

            if (existingUser == null)
                return await this.userService.AddUserAsync(user);
            else
                throw new Exception($"User already exists: {user.ClientLogin} or VPS ID: {user.VpsId}");
        }

        public async ValueTask<User> UpdateUserSourceAsync(Client client)
        {
            User? selectedUser = this.userService
                .RetrieveAllUsers()
                .Where(u => u.ClientLogin == client.ClientLogin)
                .FirstOrDefault();

            if (selectedUser != null)
            {
                selectedUser.AccountBalance = client.AccountBalance;
                selectedUser.AccountEquity = client.AccountEquity;
                selectedUser.InvestorStatus = client.InvestorStatus;
                selectedUser.ClientStatus = client.ClientStatus;
                selectedUser.ProblemDescription = client.ProblemDescription;
                selectedUser.ServerRam = client.ServerRam;
                selectedUser.ServerCpu = client.ServerCpu;
                selectedUser.LastCheckedTime = DateTime.Now;

                return await this.userService.ModifyUserAsync(selectedUser);
            }
            else
                throw new Exception($"User not found: {client.ClientLogin}");
        }

        public async ValueTask<User> DeleteUserAsync(string VpsId)
        {
            User? selectedUser = this.userService
                .RetrieveAllUsers()
                .Where(u => u.VpsId == VpsId)
                .FirstOrDefault();

            if (selectedUser == null)
                throw new Exception($"VPS not found: {VpsId}");

            return await this.userService.RemoveUserAsync(selectedUser.UserId);
        }

        public IQueryable<User> GetAllUsers() =>
            this.userService.RetrieveAllUsers();

        public async ValueTask<User> UpdateUserAsync(User user)
        {
            User? selectedUser = this.userService
                .RetrieveAllUsers()
                .Where(u => u.VpsId == user.VpsId)
                .FirstOrDefault();

            if (selectedUser != null)
            {
                user.UserId = selectedUser.UserId;

                return await this.userService.ModifyUserAsync(user);
            }
            else
                throw new Exception($"VPS not found: {user.VpsId}");
        }

    }
}