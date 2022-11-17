using Microsoft.EntityFrameworkCore;
using ClassLibrary.Entity;

namespace ClassLibrary.Repository.EF
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext>options) 
            : base(options)
        {
        }

        public EcommerceContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) //checks if options have already been set, via constructor
            {
                optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=ecommerce;User ID=sa;Password=carpond");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product("p1", "Pedigree Chum", 0.70, 1.42),
                new Product("p2", "Knife", 0.60, 1.31),
                new Product("p3", "Fork", 0.75, 1.57),
                new Product("p4", "Spaghetti", 0.90, 1.92),
                new Product("p5", "Cheddar Cheese", 0.65, 1.47),
                new Product("p6", "Bean bag", 15.20, 32.20),
                new Product("p7", "Bookcase", 22.30, 46.32),
                new Product("p8", "Table", 55.20, 134.80),
                new Product("p9", "Chair", 43.70, 110.20),
                new Product("p10", "Doormat", 3.20, 7.40)
                );

            modelBuilder.Entity<Account>().HasData(
                new Account("acc1", "John Smith", "9F86D081884C7D659A2FEAA0C55AD015A3BF4F1B2B0B822CD15D6C15B0F00A08"),
                new Account("acc2", "Jane Jones", "9F86D081884C7D659A2FEAA0C55AD015A3BF4F1B2B0B822CD15D6C15B0F00A08")
                );
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
    }
}
