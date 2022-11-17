using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Examples.Collections
{
    public class Polymorphism
    {
        public static void Main()
        {
            Product[] products = {
                new NormalGood("p1", "Pedigree Chum", 0.4),
                new NormalGood("p2", "Fork", 0.6),
                new VeblenGood("p3", "Krug Champagne", 25),
                new VeblenGood("p4", "Rolex watch", 700)
            };

            foreach (Product product in products)
            {
                Console.WriteLine($"{product.Name} Cost Price {product.CostPrice} Retail Price {product.RetailPrice:C}");
            }

            //arrays implement IList
            IList<Product> list = products;
            Console.WriteLine(list.Count);
        }
    }
}
