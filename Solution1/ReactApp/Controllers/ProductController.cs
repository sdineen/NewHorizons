using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Entity;
using ClassLibrary.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReactApp.Controllers
{
    /// <summary>
    /// Web API Controller 
    /// Called from React and WebAPIClient
    /// </summary>
    //https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-3.1#attribute-routing-for-rest-apis
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IEcommerceService ecommerceService;

        public ProductController(IEcommerceService ecommerceService)
        {
            this.ecommerceService = ecommerceService;
        }

        // api/product/partOfName? 
        [HttpGet("{partOfName?}")]
        public async Task<IActionResult> GetByNameAsync(string partOfName)
        {
            ICollection<Product> products = await ecommerceService.SelectProductsAsync(partOfName);
            return Ok(products);
        }
        // api/product/id
        [HttpGet("{id:regex(^p\\d+$)}")]
        public async Task<IActionResult> GetById(string id)
        {
            var products = await ecommerceService.SelectProductsAsync();
            Product product = products.First(p => p.Id == id);
            return Ok(product);
        }



        [HttpPost]
        public async Task<IActionResult> CreateAsync(Product product)
        {
            bool created = await ecommerceService.CreateProductAsync(product);
            if (!created)
            {
                return Conflict($"{product.Id} already exists");
            }
            return Ok(product);
        }
    }
}


//[HttpGet("{id:regex(^p\\d+$)}", Name = "GetProductsById")]
//public async Task<IActionResult> GetByIdAsync(string id)
//{
//    Product item = await ecommerceService.SelectProductByIdAsync(id);
//    if (item == null)
//    {
//        return NotFound();
//    }
//    return Ok(item);
//}

//[HttpPost]
//public async Task<IActionResult> CreateAsync([FromBody] Product product)
//{
//    if (product == null)
//    {
//        return BadRequest(ModelState);
//    }

//    bool created = await ecommerceService.CreateProductAsync(product);
//    if (!created)
//    {
//        return BadRequest($"{product.Id} already exists");
//    }

//    return Created("GetProductsById", product);
//}