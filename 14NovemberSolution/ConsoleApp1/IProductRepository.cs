using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IProductRepository
    {
        ICollection<Product>? SelectAll();
        Product? SelectById(int id);
        bool Create(Product product);
        bool Delete(int id);
        bool Update(Product product);

    }
}
