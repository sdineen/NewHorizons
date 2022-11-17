using ClassLibrary.Entity;
using ClassLibrary.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcApp.Controllers
{
    public class OrderController : Controller
    {
        private IEcommerceService ecommerceService;
        private IHttpContextAccessor context;

        public OrderController(IEcommerceService ecommerceService, IHttpContextAccessor context)
        {
            this.ecommerceService = ecommerceService;
            this.context = context;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            ICollection<Order> orders =
                //await ecommerceService.SelectOrdersByAccountIdAsync(User.Identity.Name);
                await ecommerceService.SelectOrdersByAccountIdAsync(context.HttpContext.User.Identity.Name);
            return View(orders);
        }

        // GET: Orders/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order order = await ecommerceService.SelectOrderAsync((int)id);
            return View(order);
        }
    }
}
