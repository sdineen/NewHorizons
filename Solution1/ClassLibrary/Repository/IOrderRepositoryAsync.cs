using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repository
{
    public interface IOrderRepositoryAsync
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
        Task<int> CreateAsync(Order order);


        /// <summary>
        /// Retrieve an Order with Provisional OrderStatus property
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        /// 
        Task<Order> SelectProvisionalOrderByAccountIdAsync(string accountId);

        Task<ICollection<Order>> SelectOrdersByAccountIdAsync(string accountId);
        Task<Order> SelectByOrderIdAsync(int orderId);
        Task<bool> UpdateAsync(Order order);
        Task<bool> DeleteAsync(int orderId);
    }
}
