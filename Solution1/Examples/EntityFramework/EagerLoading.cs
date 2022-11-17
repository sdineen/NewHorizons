using ClassLibrary.Entity;
using ClassLibrary.Repository.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.EntityFramework
{
    public class EagerLoading
    {
        public static void Main()
        {
            Order provisionalOrder = new Order
            {
                AccountId = "acc1",
                OrderStatus = OrderStatus.Provisional,
                LineItems = new List<LineItem>
                {
                    new LineItem { ProductId ="p1", Quantity = 2,},
                    new LineItem { ProductId ="p2", Quantity = 1 }
                }
            };
            OrderRepository or = new OrderRepository(new EcommerceContext());
            int id = or.CreateAsync(provisionalOrder).Result;
            Order order = or.SelectProvisionalOrderByAccountIdAsync("acc1").Result;
            Console.WriteLine(order);
        }
    }
}
