using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.LINQ
{
    public delegate int Delegate1(int i);

    public delegate TResult Delegate2<TSource, TResult>(TSource t);

    public class Delegates
    {
        public static int DoubleIt(int i)
        {
            return i * 2;
        }

        public static bool IsEven(int i)
        {
            return i % 2 == 0;
        }



        public static void Main()
        {
            Delegate1 d1 = new Delegate1(DoubleIt);
            Console.WriteLine(d1.Invoke(5));
            //or simply
            Console.WriteLine(d1(5));

            Delegate2<int, bool> d2 = new Delegate2<int, bool>(IsEven);
            Console.WriteLine(d2(7));

            Delegate2<int, bool> d3 = new Delegate2<int, bool>(i => i % 2 == 0);
            Console.WriteLine(d3(7));

            Func<int, bool> func = new Func<int, bool>(IsEven);
            Console.WriteLine(func(7));
        }
    }
}
