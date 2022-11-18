using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingController : ControllerBase
    {
        // GET: api/<GreetingController>
        [HttpGet]
        public string Get()
        {
            return "Hello";
        }

        // GET api/<GreetingController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok("Hello "+id);
        }

        // POST api/<GreetingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GreetingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GreetingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
