using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class NormalGood : Product
    {
        public NormalGood()
        {
        }

        public NormalGood(int id, string name, double costPrice) : base(id, name, costPrice)
        {
        }

        public override double RetailPrice 
        { 
            get => CostPrice * 2; 
        }
    }
}