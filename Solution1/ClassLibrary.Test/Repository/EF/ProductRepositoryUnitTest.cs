using ClassLibrary.Entity;
using ClassLibrary.Repository.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ClassLibrary.Test.Repository.EF
{
    public class ProductRepositoryUnitTest
    {
        protected EcommerceContext context;
        public ProductRepositoryUnitTest()
        {
            string connectionString = @"Data Source=.\sqlexpress;Initial Catalog = test; User ID = sa; Password = carpond; ConnectRetryCount=0";
            context = new EcommerceContext(new DbContextOptionsBuilder<EcommerceContext>()
                              .UseSqlServer(connectionString)
                              .Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        ~ProductRepositoryUnitTest() => context.Dispose();

        [Fact]
        public void Create_Should_Add_Product()
        {
            //arrange
            Product product = new Product("p11", "Fridge", 100, 220);
            var productRepository = new ProductRepository(context);
            //act
            bool created = productRepository.Create(product);
            //assert
            Assert.Equal(11, context.Products.Count());
        }

        [Fact]
        public void Create_ShouldNotAddDuplicate()
        {
            //arrange
            Product product = new Product("p11", "Fridge", 100, 220);
            var productRepository = new ProductRepository(context);
            //act
            bool created = productRepository.Create(product);
            Action action = () => productRepository.Create(product);
            Assert.Throws<DbUpdateException>(action);
        }

        [Fact]
        public virtual void SelectAll_Should_Return_All_Products()
        {
            //arrange
            var productRepository = new ProductRepository(context);
            //act
            ICollection<Product> products = productRepository.SelectAll();
            //assert
            Assert.Equal(10, products.Count);
        }

        [Fact]
        public void SelectById_Should_Return_Correct_Product()
        {
            //arrange
            var productRepository = new ProductRepository(context);
            //act
            Product product = productRepository.SelectById("p4");
            //assert
            Assert.Equal("Spaghetti", product.Name);
        }

        [Fact]
        public void Update_Should_Update_Product()
        {
            //arrange
            Product product = new Product("p1", "Pedigree Chum", 0.70, 1.50);
            var productRepository = new ProductRepository(context);
            //act
            productRepository.Update(product);
            //assert
            Assert.Equal(1.50, context.Products.Find("p1").RetailPrice);
        }

        [Fact]
        public void Update_ContrivedOptimisticConcurrencyConflict()
        {
            //arrange
            var productRepository = new ProductRepository(context);
            Product product1 = context.Products.Find("p1");
            Product product2 = context.Products.Find("p1");
            product1.RetailPrice = 1.50;
            product2.RetailPrice = 1.55;

            //act

            //modifying a row will update the RowVersion column value
            bool updatedProduct1 = productRepository.Update(product1);

            //product1 RowVersion property and database RowVersion  
            //column values are now unequal, so the update will fail
            bool updatedProduct2 = productRepository.Update(product2);

            //assert
            Assert.True(updatedProduct1);
            Assert.False(updatedProduct2);
        }

        [Fact]
        public void Delete_Should_Remove_Product()
        {
            //arrange
            var productRepository = new ProductRepository(context);
            //act
            productRepository.Delete("p1");
            //assert
            Assert.Equal(9, context.Products.Count());
        }
    }
}


//SqlClient performs retry with a small delay when opening the connection fails.
//This is not desired when using EnsureDeleted and EnsureCreated combination
//Simply add ConnectRetryCount = 0 to the connection string 
