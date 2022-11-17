using Microsoft.EntityFrameworkCore;
using ClassLibrary.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ClassLibrary.Repository.EF
{
    public class ProductRepository : IProductRepository, IProductRepositoryAsync
    {
        private EcommerceContext context;

        public ProductRepository(EcommerceContext context)
        {
            this.context = context;
        }

        public bool Create(Product product)
        {
            Debug.WriteLine(context.Entry(product).State);//detached
            context.Products.Add(product);
            Debug.WriteLine(context.Entry(product).State);//added
            int updates = context.SaveChanges();
            Debug.WriteLine(context.Entry(product).State);//unchanged
            return updates == 1;
        }

        public async Task<bool> CreateAsync(Product product)
        {
            try
            {
                context.Products.Add(product);
                Task<int> task = context.SaveChangesAsync();
                int count = await task;
                return count == 1;
            }
            catch(DbUpdateException)
            {
                return false;
            }
        }

        public bool Delete(string id)
        {
            Product product = context.Products.Find(id);
            Debug.WriteLine(context.Entry(product).State);//unchanged
            if (product == null)
            {
                return false;
            }
            context.Remove(product);
            Debug.WriteLine(context.Entry(product).State);//deleted
            int updates = context.SaveChanges();
            Debug.WriteLine(context.Entry(product).State);//detached
            return updates == 1;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            Product product = await context.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }
            context.Remove(product);
            return await context.SaveChangesAsync() == 1;
        }

        public ICollection<Product> SelectAll()
        {
            return context.Products.ToList();
        }

        public async Task<ICollection<Product>> SelectAllAsync()
        {
            return await context.Products.ToListAsync();
        }

        public Product SelectById(string id)
        {
            return context.Products.Find(id);
        }

        public async Task<Product> SelectByIdAsync(string id)
        {
            return await context.Products.FindAsync(id);
        }

        public async Task<ICollection<Product>> SelectByNameAsync(string name)
        {
            return await context.Products.Where(p => p.Name.Contains(name)).ToListAsync();
        }

        public bool Update(Product modifiedProduct)
        {
            Product product = context.Products.Find(modifiedProduct.Id);
            Debug.WriteLine(context.Entry(product).State);//unchanged
            if (product == null)
            {
                return false;
            }
            product.CostPrice = modifiedProduct.CostPrice;
            product.RetailPrice = modifiedProduct.RetailPrice;
            Debug.WriteLine(context.Entry(product).State);//modified
            int updates = context.SaveChanges();
            Debug.WriteLine(context.Entry(product).State);//unchanged
            return updates == 1;
        }

        public async Task<bool> UpdateAsync(Product modifiedProduct)
        {
            Product product = await context.Products.FindAsync(modifiedProduct.Id);
            if (product == null)
            {
                return false;
            }
            product.CostPrice = modifiedProduct.CostPrice;
            product.RetailPrice = modifiedProduct.RetailPrice;
            int updates = await context.SaveChangesAsync();
            return updates == 1;
        }
    }
}
