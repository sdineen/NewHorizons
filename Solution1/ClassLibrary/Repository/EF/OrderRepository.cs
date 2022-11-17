using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using ClassLibrary.Entity;
using System;
using System.Diagnostics;

namespace ClassLibrary.Repository.EF
{
    public class OrderRepository : IOrderRepositoryAsync
    {
        private EcommerceContext context;

        public OrderRepository(EcommerceContext context) 
            => this.context = context;        

        public async Task<int> CreateAsync(Order order)
        {
            if (context.Orders.Any(o => o.AccountId == order.AccountId
             && o.OrderStatus == OrderStatus.Provisional))
            {
                throw new InvalidOperationException(
                    "A provisional order for this AccountId already exists");
            }
            context.Add(order); 
            await context.SaveChangesAsync();
            return order.OrderId;
        }

        //Eager loading
        public async Task<Order> SelectByOrderIdAsync(int orderId)
        {
            return await context.Orders
                .Include(o => o.Account)
                .Include(o => o.LineItems)
                .ThenInclude(li => li.Product)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<ICollection<Order>> SelectOrdersByAccountIdAsync(string accountId)
        {
            return await context.Orders
                .Include(o => o.Account)
                .Include(o => o.LineItems)
                .ThenInclude(li => li.Product)
                .Where(o => o.AccountId == accountId).ToListAsync();
        }

        public async Task<Order> SelectProvisionalOrderByAccountIdAsync(
                                                        string accountId)
        {
            Order order = await context.Orders
                .Include(o => o.Account)
                .Include(o => o.LineItems)
                .ThenInclude(li => li.Product)
                .FirstOrDefaultAsync(o => o.AccountId == accountId
            && o.OrderStatus == OrderStatus.Provisional);
            return order;
        }

        public async Task<bool> UpdateAsync(Order order)
        {
            context.Entry(order).State = EntityState.Modified;          
            int rowsUpdated = await context.SaveChangesAsync();
            return rowsUpdated == 1;
        }

        public async Task<bool> DeleteAsync(int orderId)
        {
            Order order = context.Orders.Include(o => o.LineItems).FirstOrDefault(o => o.OrderId == orderId);
            context.Orders.Remove(order);

            foreach (LineItem lineItem in order.LineItems)
            {
                context.LineItems.Remove(lineItem);
            }
            int rows = await context.SaveChangesAsync();
            return true;
        }
    }
}