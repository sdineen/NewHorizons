using ClassLibrary.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary.Repository
{
    public interface IProductRepository
    {
        ICollection<Product> SelectAll();
        Product SelectById(string id);
        bool Create(Product product);
        bool Delete(string id);
        bool Update(Product product);
    }
}