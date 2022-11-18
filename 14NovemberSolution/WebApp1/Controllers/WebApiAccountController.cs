using ConsoleApp1;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebApiAccountController : ControllerBase
    {
        private IAccountRepository accountRepository;

        public WebApiAccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }


        // GET api/<WebApiAccountController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await accountRepository.SelectById(id));
        }

         // POST api/<WebApiAccountController>
         [HttpPost]
        public void Post([FromBody] Account account)
        {
            accountRepository.Create(account);
        }

        // PUT api/<WebApiAccountController>/5
        [HttpPut]
        public void Put([FromBody] Account account)
        {
            accountRepository.Update(account);
        }

        // DELETE api/<WebApiAccountController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            accountRepository.Delete(id);
        }
    }
}
