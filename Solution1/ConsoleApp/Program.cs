

using ClassLibrary.Repository.EF;
using Examples.SQL;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace ConsoleApp
{


    class Program
    {
        static void Main(string[] args)
        {
            new ProductRepository(new EcommerceContext())
.SelectAll().ToList().ForEach(p => Console.WriteLine(p.Name));

        }

    }

}
