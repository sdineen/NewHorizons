using Microsoft.AspNetCore.Mvc;

namespace WebApp1.Controllers
{
    public class SimpleController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hello");
        }

        public IActionResult ProductList()
        {
            return View();
        }
    }
}
