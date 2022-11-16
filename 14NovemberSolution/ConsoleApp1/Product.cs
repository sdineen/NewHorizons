using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Product : Object
    {
        public Product()
        {
        }

        public Product(int id, string name, double costPrice, double retailPrice = 0)
        {
            Id = id;
            Name = name;
            CostPrice = costPrice;
            //RetailPrice = retailPrice;
        }

        public override bool Equals(object? obj) =>
            obj is Product && (obj as Product).Id == Id;

            //Product? otherProduct = obj as Product;
            //if (otherProduct != null)
            //{
            //    return false;
            //}
            //return Id == otherProduct.Id;
        

        public int Id { get; set; }
        public string? Name { get; set; }
        public double CostPrice { get; set; }
        public virtual double RetailPrice { get;  }
    }
}
