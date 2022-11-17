using ClassLibrary.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary.Repository
{
    public interface IProductRepositoryAsync
    {
        Task<ICollection<Product>> SelectAllAsync();
        Task<ICollection<Product>> SelectByNameAsync(string name);
        Task<Product> SelectByIdAsync(string id);
        Task<bool> CreateAsync(Product product);
        Task<bool> DeleteAsync(string id);
        Task<bool> UpdateAsync(Product product);

    }
}