using System;
using System.Threading.Tasks;
using ClassLibrary.Entity;
using ClassLibrary.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactApp.DTO;

namespace ReactApp.Controllers
{

    /// <summary>
    /// WebAPI controller
    /// Called from React and WebAPIClient
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IEcommerceService ecommerceService;

        public OrderController(IEcommerceService ecommerceService)
        {
            this.ecommerceService = ecommerceService;
        }

        //[AllowAnonymous]
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok();
        }


        [HttpGet("{username}")]
        public async Task<IActionResult> Basket(string username)
        {
            Order order = await
                ecommerceService.SelectProvisionalOrderAsync(username);
            return Ok(order);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userParameters">product id and username</param>
        /// <returns>order</returns>
        [HttpPost]
        public async Task<IActionResult> AddProduct(UserParameters userParameters)
        {
            try
            {
                Order order = await ecommerceService.AddProductToOrderAsync(userParameters.ProductId, userParameters.Username);
                return Ok(order);
            }
            catch (InvalidOperationException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("remove")]
        public async Task<IActionResult> RemoveProduct(UserParameters userParameters)
        {
            try
            {
                Order order = await ecommerceService.RemoveProductFromOrderAsync(userParameters.ProductId, userParameters.Username);
                return Ok(order);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        //Methods PUT and DELETE are idempotent (multiple identical requests should have the same effect as a single request)
        //https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-3.1#frombody-inference-notes
        [HttpPut("{username}")]
        public async Task<IActionResult> ConfirmOrderAsync(string username)
        {
            bool confirmed = await ecommerceService.ConfirmOrderAsync(username);
            if (!confirmed)
            {
                return NotFound();
            }
            return new NoContentResult();
        }
    }
}