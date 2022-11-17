using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.DesignPatterns.Template_Method
{
    public class Class1
    {
        static void Main(string[] args)
        {
            AbstractClass a = new WarmClimate();
            a.TemplateMethod();
            Console.ReadKey();
        }
    }
}
