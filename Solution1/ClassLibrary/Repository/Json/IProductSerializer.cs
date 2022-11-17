using ClassLibrary.Entity;
using System.Collections.Generic;

namespace ClassLibrary.Repository.JSON
{
    public interface IProductSerializer
    {
        HashSet<Product> ReadProducts();
        void WriteProducts(HashSet<Product> products);
    }
}