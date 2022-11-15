using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class VeblenGood : Product
    {
        public VeblenGood()
        {
        }

        public VeblenGood(int id, string name, int costPrice) : base(id, name, costPrice)
        {
        }

        public override double RetailPrice 
        { 
            get => 5 * CostPrice; 
        }
    }
}
