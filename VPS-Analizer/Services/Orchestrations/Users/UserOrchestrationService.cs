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

        public async ValueTask<User> AddUserAsync(List<User> recieveUser)
        {
            foreach (var item in recieveUser)
            {
                IQueryable<User> users = this.userService.RetrieveAllUsers();
                User? existingUser = users
                    .Where(u => u.ClientLogin == item.ClientLogin || u.VpsId == item.VpsId)
                    .FirstOrDefault();
                if (existingUser == null)
                    await this.userService.AddUserAsync(item);
                else
                    throw new Exception($"User already exists: {item.ClientLogin} or VPS ID: {item.VpsId}");
            }

            return recieveUser.Last();
        }

        public async ValueTask<User> UpdateUserSourceAsync(Client client)
        {
            User? selectedUser = this.userService
                .RetrieveAllUsers()
                .Where(u => u.VpsId == client.VpsId)
                .FirstOrDefault();

            if (selectedUser != null)
            {
                selectedUser.ClientLogin = client.ClientLogin;
                selectedUser.AccountBalance = client.AccountBalance;
                selectedUser.AccountEquity = client.AccountEquity;
                selectedUser.InvestorStatus = client.RobotStatus;
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