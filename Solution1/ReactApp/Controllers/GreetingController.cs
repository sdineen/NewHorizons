using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactApp.Controllers
{
    [Route("api/[controller]")]
    public class GreetingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Greet()
        {
            return Ok("Good morning");
        }        
    }
}
