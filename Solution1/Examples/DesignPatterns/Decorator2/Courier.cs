using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.DesignPatterns.Decorator2
{
    public class Courier : Package
    {
        public Courier(IPackage package):base(package)
        {
        }
        //added state or behaviour
        public string DeliveryInstructions { get; set; }
    
        //modified behaviour
        public override double RetailPrice
        {
            get
            {
                return package.RetailPrice + 10;
            }
        }
    }
}
