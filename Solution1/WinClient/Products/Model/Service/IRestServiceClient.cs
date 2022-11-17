using ClassLibrary.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WinClient.Products.Model.Service
{
    public interface IRestServiceClient
    {
        Task<IEnumerable<Product>> SelectByNameAsync(string name = null);
        Task<bool> Authenticate(string username, string password);
        Task<Order> AddProductToOrder(string productId, string username);
        Task<Order> GetBasket(string username);
        Task<bool> ConfirmOrder(string username);
    }
}