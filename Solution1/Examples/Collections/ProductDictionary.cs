using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Collections
{
    public class ProductDictionary
    {
        public static void Main()
        {
            var keyValuePairs = new Dictionary<string, Product>();
            keyValuePairs.Add("p2", new Product("p2", "Knife", 0.60, 1.31));
            keyValuePairs.Add("p3", new Product("p3", "Fork", 0.75, 1.57));
            keyValuePairs.Add("p4", new Product("p4", "Spaghetti", 0.90, 1.92));
            
            Product product;
            bool retrieved = keyValuePairs.TryGetValue("p5", out product);
            Console.WriteLine(product?.Name);
            
            Console.WriteLine(keyValuePairs["p2"]); //can throw KeyNotFoundException

            var keys = keyValuePairs.Keys;
            var values = keyValuePairs.Values;
        }

        private static IEnumerable<Product> products = new List<Product> {
                new Product("p1", "Pedigree Chum", 0.70, 1.42),
                new Product("p2", "Knife", 0.60, 1.31),
                new Product("p3", "Fork", 0.75, 1.57),
                new Product("p4", "Spaghetti", 0.90, 1.92),
                new Product("p5", "Cheddar Cheese", 0.65, 1.47),
                new Product("p6", "Bean bag", 15.20, 32.20),
                new Product("p7", "Bookcase", 22.30, 46.32),
                new Product("p8", "Table", 55.20, 134.80),
                new Product("p9", "Chair", 43.70, 110.20),
                new Product("p10", "Doormat", 3.20, 7.40)
        };
    }
}
