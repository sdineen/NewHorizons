using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.DesignPatterns.Template_Method
{
    public class CoolClimate : AbstractClass
    {
        public override void ClimateControl()
        {
            Console.WriteLine("Heating");
        }
    }
}


