using System.Collections.Generic;
using System.Linq;
using ClassLibrary.Entity;

namespace ClassLibrary.Repository.JSON
{
    public class ProductRepository : IProductRepository
    {
        private IProductSerializer serializer;
        private HashSet<Product> products;

        public IProductSerializer Serializer {get; set; }

        public ProductRepository(IProductSerializer serializer)
        {
            this.serializer = serializer;
            //null coalescing operator ?? returns left hand operand if not null; 
            //otherwise, right-hand operand 
            products = serializer.ReadProducts() ?? new HashSet<Product>();
        }

        public bool Create(Product product)
        {
            bool added = products.Add(product);
            serializer.WriteProducts(products); 
            return added;
        }

        public bool Delete(string id)
        {
            int count = products.RemoveWhere(p => p.Id == id);
            serializer.WriteProducts(products);
            return count == 1;
        }

        public ICollection<Product> SelectAll()
        {
            return serializer.ReadProducts();
        }

        public Product SelectById(string id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public bool Update(Product product)
        {
            if (products.Remove(product))
            {
                bool added = products.Add(product);
                serializer.WriteProducts(products);
                return added;
            }
            return false;
        }
    }
}
