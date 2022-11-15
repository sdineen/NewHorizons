
using ConsoleApp1;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyApp
{
    internal class Program
    {
        static void Main(String[] args)
        {

            //build a 4 element array of type Product
            //Product[] products = new Product[4];
            List<Product> arrayList= new List<Product>();

            //add two NormalGood objects and two VeblenGood objects to the array
            arrayList.Add(new  NormalGood(1, "Pedigree Chum", 0.4));
            arrayList.Add(new NormalGood(2, "Fork", 0.6));
            arrayList.Add(new VeblenGood(3, "Krug Champagne", 25));
            arrayList.Add(new VeblenGood(4, "Rolex watch", 700));

            //arrayList.Add("some text");

            //write a foreach loop to iterate through the array,
            //   displaying the name and retail price of each product

            foreach (Product product in arrayList)
            {
                Console.WriteLine($"{product.Name} Cost Price {product.CostPrice:C} Retail Price {product.RetailPrice:C} ");
            }


        }


    }
}