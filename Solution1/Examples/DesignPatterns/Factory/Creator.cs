using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.DesignPatterns.Factory
{
    public abstract class Creator
    {
        public abstract Product GetProduct();
    }

    public class VeblenCreator : Creator
    {
        public override Product GetProduct()
        {
            Product product = new VeblenGood();
            //Do something with the object 
            product.Id = "p1";
            return product;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Creator creator = new VeblenCreator();
            Product product = creator.GetProduct();
        }
    }
}
