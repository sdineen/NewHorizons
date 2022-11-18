using ConsoleApp1;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepositoryAsync productRepository;

        public ProductController(IProductRepositoryAsync productRepository)
        {
            this.productRepository = productRepository;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            ICollection<Product> products = await productRepository.SelectAllAsync();
            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            Product product = await productRepository.SelectByIdAsync(id);
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            productRepository.Create(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            bool updated = productRepository.Update(product);
            if (updated)
            {
                return Ok();
            }
            else
            {
                return new NotFoundResult();
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
