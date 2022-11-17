using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Product product = context.Products.Find(id);
            if (product == null)
            {
                return false;
            }
            context.Remove(product);
            return context.SaveChanges() == 1;

        }

        public ICollection<Product>? SelectAll()
        {
            return context.Products.ToList();
        }

        public Product? SelectById(int id)
        {
            return context.Products.Find(id);
        }

        public bool Update(Product modifiedProduct)
        {
            Debug.WriteLine(context.Entry(modifiedProduct).State);

            Product? product = context.Products.Find(modifiedProduct.Id);
            Debug.WriteLine(context.Entry(product).State);
            if (product == null)
            {
                return false;
            }
            product.CostPrice = modifiedProduct.CostPrice;
            product.RetailPrice = modifiedProduct.RetailPrice;
            Debug.WriteLine(context.Entry(product).State);
            bool added =  context.SaveChanges() == 1;
            Debug.WriteLine(context.Entry(product).State);
            return added;


        }
    }
}
