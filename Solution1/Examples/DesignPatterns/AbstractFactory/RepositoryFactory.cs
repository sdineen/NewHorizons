using ClassLibrary.Repository;
using ClassLibrary.Repository.EF;
using ClassLibrary.Repository.Sql;

namespace Examples.DesignPatterns.AbstractFactory
{
    interface IRepositoryFactory
    {
        public IProductRepository ProductRepository { get; }
        public IAccountRepository AccountRepository { get; }
    }

    class SqlRepositoryFactory : IRepositoryFactory
    {
        private string connStr = ""; 
        public IProductRepository ProductRepository
            => new SqlProductRepository(connStr);

        public IAccountRepository AccountRepository 
            => new SqlAccountRepository(connStr);

    }

    class EfRepositoryFactory : IRepositoryFactory
    {
        private EcommerceContext context;
        public IProductRepository ProductRepository
            => new ProductRepository(context);

        public IAccountRepository AccountRepository
            => new AccountRepository(context);

    }

    public class Program
    {
        public static void Main()
        {
            IRepositoryFactory factory = new EfRepositoryFactory();
            IProductRepository productRepository = factory.ProductRepository;
            IAccountRepository accountRepository = factory.AccountRepository;
        }
    }

}
