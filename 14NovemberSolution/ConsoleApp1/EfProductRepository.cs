using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class EfProductRepository : IProductRepository, IProductRepositoryAsync
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

        public async Task<bool> CreateAsync(Product product)
        {
            context.Products.Add(product);
            //Task<int> task = context.SaveChangesAsync();
            //int count = await task;

            int count = await context.SaveChangesAsync();
            return count > 0;
        }

        public bool Delete(int id)
        {
            Product? product = context.Products.Find(id);
            if (product == null)
            {
                return false;
            }
            context.Remove(product);
            return context.SaveChanges() == 1;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Product? product = await context.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }
            context.Remove(product);
            return await context.SaveChangesAsync() == 1;
        }

        public ICollection<Product>? SelectAll()
        {
            return context.Products.ToList();
        }

        public async Task<ICollection<Product>>? SelectAllAsync()
        {
            return await context.Products.ToListAsync();
        }

        public Product? SelectById(int id)
        {
            return context.Products.Find(id);
        }

        public async Task<Product>? SelectByIdAsync(int id)
        {
            return await context.Products.FindAsync(id);
        }

        public bool Update(Product modifiedProduct)
        {
            Debug.WriteLine(context.Entry(modifiedProduct).State);

            Product? product = context.Products.Find(modifiedProduct.Id);

            if (product == null)
            {
                return false;
            }
            product.CostPrice = modifiedProduct.CostPrice;
            product.RetailPrice = modifiedProduct.RetailPrice;
            Debug.WriteLine(context.Entry(product).State);
            bool added = context.SaveChanges() == 1;
            Debug.WriteLine(context.Entry(product).State);
            return added;
        }

        public async Task<bool> UpdateAsync(Product modifiedProduct)
        {
            Debug.WriteLine(context.Entry(modifiedProduct).State);

            Product? product = await context.Products.FindAsync(modifiedProduct.Id);
            Debug.WriteLine(context.Entry(product).State);
            if (product == null)
            {
                return false;
            }
            product.CostPrice = modifiedProduct.CostPrice;
            product.RetailPrice = modifiedProduct.RetailPrice;
            Debug.WriteLine(context.Entry(product).State);
            bool added = await context.SaveChangesAsync() == 1;
            Debug.WriteLine(context.Entry(product).State);
            return added;
        }
    }
}
