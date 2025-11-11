using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace VPS_Analizer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : RESTFulController
    {
        public HomeController() { }

        [HttpGet]
        public string SayHello()
        {
            return "Best!!";
        }
    }
}
