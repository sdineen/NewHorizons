using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Collections
{
    public class SortedSetExample
    {
        class ByName : IComparer<Product>
        {
            public int Compare(Product x, Product y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }
        public static void Main()
        {
            var comparer = new ByName();
            var set = new SortedSet<Product>(products, comparer);
            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }
        private static IEnumerable<Product> products = new List<Product> {
                new Product("p1", "Pedigree Chum", 0.70, 1.42),
                new Product("p2", "Knife", 0.60, 1.31),
                new Product("p3", "Fork", 0.75, 1.57),
                new Product("p4", "Spaghetti", 0.90, 1.92)
        };
    }
}
