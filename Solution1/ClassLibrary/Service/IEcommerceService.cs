using ClassLibrary.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary.Service
{
    public interface IEcommerceService 
    {
        /// <summary>
        /// returns all products if no argument
        /// </summary>
        /// <param name="partOfName">part of a product's name</param>
        Task<ICollection<Product>> SelectProductsAsync(string partOfName = null);

        /// <summary>
        /// add the product to the provisional order with the specified accountId
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="accountId"></param>
        Task<Order> AddProductToOrderAsync(string productId, string accountId);

        /// <summary>
        /// Creates a new Order with the specified AccountId and with OrderStatus = Provisional
        /// or returns an existing Provisional Order for the AccountId
        /// Called from ProductController in MvcApp and OrderController in ReactApp
        /// </summary>
        /// <param name="accountId"></param>
        Task<Order>SelectProvisionalOrderAsync(string accountId);


        /// <summary>
        /// change the status of the provisional order with the specified 
        /// accountId to confirmed
        /// </summary>
        Task<bool> ConfirmOrderAsync(string accountId);

        /// <summary>
        /// remove the product from the provisional order with the specified 
        /// accountId
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<Order> RemoveProductFromOrderAsync(string productId, string accountId);

        /// <summary>
        /// Called from onPostAsync method of RegisterModel class of MVC app
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        bool CreateAccount(Account product);

        /// <summary>
        /// Retrieve authenticated account for React app
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="AuthenticationException ">invalid username and password</exception>
        Account SelectAuthenticatedAccount(string username, string password);

        /// <summary>
        /// Called from Create method of ProductController 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<bool> CreateProductAsync(Product product);

        /// <summary>
        /// Called from Index method of OrderController
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>        
        Task<ICollection<Order>> SelectOrdersByAccountIdAsync(string accountId);

        /// <summary>
        /// Called from Details method of OrderController
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<Order> SelectOrderAsync(int orderId);

    }
}