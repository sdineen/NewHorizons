using ClassLibrary.Entity;
using ClassLibrary.Repository.EF;
using ClassLibrary.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.ServiceLayer
{
    public class AddProduct
    {
        public static void Main()
        {
            EcommerceContext context = new EcommerceContext();
            EcommerceService service = new EcommerceService(
                new AccountRepository(context), 
                new ProductRepository(context), 
                new OrderRepository(context));

            Order order = service.AddProductToOrderAsync("p1", "acc1").Result;

            Console.WriteLine(order);
        }

    }
}
