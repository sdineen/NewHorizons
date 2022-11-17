using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.MoreKeywords
{
    public class Dynamic
    {
        public static void Main()
        {
            //nullable type
            int? i = null;

            //the compiler infers the type of the variable from 
            //the expression on the right side of the initialization statement
            var v = GetSomeObject();
            //Console.WriteLine(v.Year);

            //dynamic types resolved at runtime 
            dynamic d = GetSomeObject();
            Console.WriteLine(d.Year);

            Console.ReadKey();
        }

        public static object GetSomeObject()
        {
            return DateTime.Now;
        }
    }

}
