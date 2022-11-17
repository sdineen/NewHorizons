using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using ClassLibrary.Entity;
using ClassLibrary.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MvcApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IEcommerceService ecommerceService;
        private readonly IHttpContextAccessor context;

        public ProductController(IEcommerceService ecommerceService, IHttpContextAccessor context = null)
        {
            this.ecommerceService = ecommerceService;
            this.context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index(string id = null)
        {
            ViewBag.SearchText = id; //used to retain text in input field
            return View(await ecommerceService.SelectProductsAsync(id));
        }

        //GET: Product/AddProduct/5
        [Authorize]
        public async Task<IActionResult> AddProduct(string id)
        {
            Order order = await  ecommerceService.AddProductToOrderAsync(id, context.HttpContext.User.Identity.Name);
            return View("Basket", order.LineItems);
        }

        private void DebugClaims()
        {
            ClaimsPrincipal principal = User as ClaimsPrincipal;
            if (null != principal)
            {
                foreach (Claim claim in principal.Claims)
                {
                    Debug.WriteLine("CLAIM TYPE: " + claim.Type + "; CLAIM VALUE: " + claim.Value + "</br>");
                }
            }
        }

        //GET: Product/Basket
        [Authorize]
        public async Task<IActionResult> Basket()
        {
            Order order = await
                ecommerceService.SelectProvisionalOrderAsync(context.HttpContext.User.Identity.Name);
            return View(order.LineItems);
        }

        //GET: Product/AddProduct/5
        [Authorize]
        public async Task<IActionResult> Purchase()
        {
            await ecommerceService.ConfirmOrderAsync(context.HttpContext.User.Identity.Name);
            return View();
        }

        // GET: Product/RemoveProductFromOrder/5
        public async Task<IActionResult> RemoveProductFromOrder(string id)
        {
            await ecommerceService.RemoveProductFromOrderAsync(id, context.HttpContext.User.Identity.Name);
            return RedirectToAction(nameof(Basket));
        }


        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await ecommerceService.CreateProductAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

    }
}