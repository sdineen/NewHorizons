using ClassLibrary.Entity;
using ClassLibrary.Repository.EF;

namespace Examples.DesignPatterns.Adapter
{
    public class Client
    {
        static ITarget target;
        static void Main()
        {
            var context = new EcommerceContext();
             target = new Adapter(new ProductRepository(context));
            target.AddProduct(new Product{ Id = "p1", Name="Pedigree chum" });
            target.RemoveProduct(new Product { Id = "p1" });
        }
    }
}
