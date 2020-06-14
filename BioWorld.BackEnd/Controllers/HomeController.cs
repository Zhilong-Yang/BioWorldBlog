using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
