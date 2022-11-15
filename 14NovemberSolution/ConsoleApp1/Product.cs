using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Product
    {
        public Product()
        {
        }

        public Product(int id, string name, double costPrice, double retailPrice)
        {
            Id = id;
            Name = name;
            CostPrice = costPrice;
            RetailPrice = retailPrice;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public double CostPrice { get; set; }
        public double RetailPrice { get; set; }
    }
}
