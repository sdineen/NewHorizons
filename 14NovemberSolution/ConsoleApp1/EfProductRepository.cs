using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class EfProductRepository : IProductRepository
    {
        private ECommerceContext context;

        public EfProductRepository(ECommerceContext context)
        {
            this.context = context;
        }

        public bool Create(Product product)
        {
            context.Products.Add(product);
            int updates = context.SaveChanges();
            return updates > 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Product>? SelectAll()
        {
            return context.Products.ToList();
        }

        public Product? SelectById(int id)
        {
            return context.Products.Find(id);
        }

        public bool Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
