using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.DesignPatterns.Template_Method
{
    public abstract class AbstractClass
    {
        public void TemplateMethod()
        {
            DisableAlarm(); //implemented
            ClimateControl(); //abstract
        }
        public void DisableAlarm()
        {
            Console.WriteLine("Alarm disabled");
        }
        public abstract void ClimateControl();
    }
}
