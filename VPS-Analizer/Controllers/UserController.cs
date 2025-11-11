using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using VPS_Analizer.Models.Clients;
using VPS_Analizer.Models.Users;
using VPS_Analizer.Services.Orchestrations.Users;

namespace VPS_Analizer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : RESTFulController
    {
        private readonly IUserOrchestrationService userOrchestrationService;
        public UserController(IUserOrchestrationService userOrchestrationService) =>
            this.userOrchestrationService = userOrchestrationService;

        [HttpPost("AddVPS")]
        public async ValueTask<ActionResult<User>> AddUser(User user) =>
            await this.userOrchestrationService.AddUserAsync(user);

        [HttpGet("GetAllVPS")]
        public async ValueTask<IQueryable<User>> GetUsersList() =>
            this.userOrchestrationService.GetAllUsers();

        [HttpPut("PutVPSSource")]
        public async ValueTask<ActionResult<User>> PutUserSource(Client client) =>
            await this.userOrchestrationService.UpdateUserSourceAsync(client);

        [HttpPut("PutVPS")]
        public async ValueTask<ActionResult<User>> PutUser(User user) =>
            await this.userOrchestrationService.UpdateUserAsync(user);

        [HttpDelete("DeleteVPSById")]
        public async ValueTask<ActionResult<User>> DeleteUser(string VpsId) =>
            await this.userOrchestrationService.DeleteUserAsync(VpsId);
    }
}
