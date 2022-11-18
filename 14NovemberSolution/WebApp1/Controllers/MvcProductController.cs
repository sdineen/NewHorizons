using ConsoleApp1;
using Microsoft.AspNetCore.Mvc;

namespace WebApp1.Controllers
{
    public class MvcProductController : Controller
    {
        private IProductRepositoryAsync productRepository;

        public MvcProductController(IProductRepositoryAsync productRepository) {
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return Content("Hello");
        }

        public IActionResult ProductList()
        {
            ICollection<Product>? products = productRepository.SelectAll();
            return View(products);
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product) 
        {
            bool added = productRepository.Create(product);
            if(!added)
            {
                RedirectToAction("Create");
            }
            return RedirectToAction("ProductList");
        }
    }
}
