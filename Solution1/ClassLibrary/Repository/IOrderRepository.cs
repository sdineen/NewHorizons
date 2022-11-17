using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repository
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Create a new Order with OrderStatus set to Provisional
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">
        /// Existing Order with the same AccountId and 
        /// with OrderStatus set to Provisional
        /// </exception>
        int Create(Order order);

        /// <summary>
        /// Retrieve an Order with Provisional OrderStatus property
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Order SelectProvisionalOrderByAccountId(string accountId);

        Order SelectByOrderId(int orderId);
        bool Update(Order order);
        bool Delete(int orderId);
        
    }
}
