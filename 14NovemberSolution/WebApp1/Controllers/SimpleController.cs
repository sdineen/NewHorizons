using ConsoleApp1;
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
            //List<Product> productList = new List<Product>();
            //productList.Add(new NormalGood(1, "Pedigree Chum", 0.4));
            //productList.Add(new NormalGood(2, "Fork", 0.6));
            //productList.Add(new VeblenGood(3, "Krug Champagne", 25));
            //productList.Add(new VeblenGood(4, "Rolex watch", 700));

            return View(productList);
        }

                    //List<Product> productList= new List<Product>();

            //add two NormalGood objects and two VeblenGood objects to the array
            //productList.Add(new  NormalGood(1, "Pedigree Chum", 0.4));
            //productList.Add(new NormalGood(2, "Fork", 0.6));
            //productList.Add(new VeblenGood(3, "Krug Champagne", 25));
            //productList.Add(new VeblenGood(4, "Rolex watch", 700));
    }
}
