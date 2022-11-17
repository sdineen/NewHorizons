using ClassLibrary.Entity;
using ClassLibrary.Repository;
using System;
using System.Threading;

namespace Examples.DesignPatterns.Adapter
{
    public class Adapter : ITarget
    {
        private IProductRepository adaptee;

        public Adapter(IProductRepository productRepository)
            => adaptee = productRepository;

        public void AddProduct(Product p)
        {
            adaptee.Create(p);
        }

        public void RemoveProduct(Product p)
        {
            adaptee.Delete(p.Id);
        }
    }
}
