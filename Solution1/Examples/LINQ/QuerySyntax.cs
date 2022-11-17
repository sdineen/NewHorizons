using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Examples.LINQ
{
    class QuerySyntax
    {
        static void Main()
        {
            QuerySyntax1();
        }
        public static void QuerySyntax1()
        {
            //Data source

            int[] numbers = { 0, 1, 2, 3, 4, 5, 6 };

            //	Query creation

            IEnumerable<int> numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            //	Query execution

            foreach (int num in numQuery)
            {
                Console.WriteLine(num);
            }
        }

        public static void QuerySyntax2()
        {
            ICollection<Product> products = new List<Product> {
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

            IEnumerable<string> result = null;

            //find product names with a retail price below 50
            result = from p in products
                     where p.RetailPrice < 50
                     select p.Name;

            foreach (string s in result)
            {
                Console.WriteLine(s);
            }
        }
    }
}
