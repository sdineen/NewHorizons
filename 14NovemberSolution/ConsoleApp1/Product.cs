using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Product
    {
        private int id;
        private string name;
        private double costPrice;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double CostPrice
        {
            get { return costPrice; }
            set { costPrice = value; }
        }
    }
}
