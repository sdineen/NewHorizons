using ConsoleApp1;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository productRepository;

        //public HomeController(IProductRepository productRepository)
        //{
        //    this.productRepository = productRepository;
            
        //}

        public IActionResult Index()
        {
            IProductRepository productRepository = new EfProductRepository(new ECommerceContext());
            var products = productRepository.SelectAll();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}