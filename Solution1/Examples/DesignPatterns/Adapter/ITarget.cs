using ClassLibrary.Entity;

namespace Examples.DesignPatterns.Adapter
{
    public interface ITarget
    {
        void AddProduct(Product p);
        void RemoveProduct(Product p);
    }
}
