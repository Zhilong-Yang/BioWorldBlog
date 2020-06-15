using Microsoft.AspNetCore.Mvc;

namespace BioWorld.BackEnd.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("BioWorld Blog BackEnd Service");
    }
}