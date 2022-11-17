using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Variance
{
    class Variance
    {
        static void Main(string[] args)
        {
            //                                     in - contravariant parameter can be less derived (Object)
            //                                              out - covariant parameter can be more derived (VeblenGood)
            Func<Product, Product> func = new Func<Product, Product>(Target);
        }

        private static VeblenGood Target(Object arg)
        {
            throw new NotImplementedException();
        }
    }
}
