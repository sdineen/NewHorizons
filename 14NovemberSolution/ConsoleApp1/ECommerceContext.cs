using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ECommerceContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product(1, "Pedigree Chum", 0.70, 1.42),
                new Product(2, "Knife", 0.60, 1.31),
                new Product(3, "Fork", 0.75, 1.57),
                new Product(4, "Spaghetti", 0.90, 1.92),
                new Product(5, "Cheddar Cheese", 0.65, 1.47),
                new Product(6, "Bean bag", 15.20, 32.20),
                new Product(7, "Bookcase", 22.30, 46.32),
                new Product(8, "Table", 55.20, 134.80),
                new Product(9, "Chair", 43.70, 110.20),
                new Product(10, "Doormat", 3.20, 7.40)
                );

            modelBuilder.Entity<Account>().HasData(
             new Account("acc1", "John Smith",
                       "9F86D081884C7D659A2FEAA0C55AD015A3BF4F1B2B0B822CD15D6C15B0F00A08"),
            new Account("acc2", "Jane Jones",
                       "9F86D081884C7D659A2FEAA0C55AD015A3BF4F1B2B0B822CD15D6C15B0F00A08")
           );
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
