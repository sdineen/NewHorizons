using ClassLibrary.Entity;
using System;
using System.Text;

namespace Examples.Variance
{
    delegate void MyAction<in T>(T obj);

    class InParameters
    {
        public static void Main()
        {
            MyAction<Object> lessDerivedParameter = (target) => { Console.WriteLine(target.GetType().Name); };
            MyAction<StringBuilder> moreDerivedParameter = lessDerivedParameter;
            moreDerivedParameter(new StringBuilder());
        }
    }
}
