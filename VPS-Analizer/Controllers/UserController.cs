using MeneMarket.Services.Foundations.Users;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using VPS_Analizer.Models.Users;

namespace VPS_Analizer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : RESTFulController
    {
        private readonly IUserService userService;
        public UserController(IUserService userService) 
        { 
            this.userService = userService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<User>> AddUser(User user) =>
            await this.userService.AddUserAsync(user);

        [HttpGet]
        public async ValueTask<IQueryable<User>> GetUsersList() =>
            this.userService.RetrieveAllUsers();
    }
}
