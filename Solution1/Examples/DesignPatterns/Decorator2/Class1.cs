using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.DesignPatterns.Decorator2
{
    class Class1
    {
        static void Main(string[] args)
        {
            VeblenGood veblenGood = new VeblenGood {CostPrice = 500 };
            Console.WriteLine($"Retail price £{veblenGood.RetailPrice}");

            Post p = new Post(veblenGood);
            Console.WriteLine($"Retail price including postage £{p.RetailPrice}");

            Courier c = new Courier(veblenGood);
            c.DeliveryInstructions = "Leave by back door";
            Console.WriteLine($"Retail price including courier £{c.RetailPrice}, {c.DeliveryInstructions}");


            Console.ReadKey();
        }
    }
}
