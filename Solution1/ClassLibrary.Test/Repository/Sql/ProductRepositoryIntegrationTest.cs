using ClassLibrary.Entity;
using ClassLibrary.Repository.Sql;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace ClassLibrary.Test.Repository.Sql
{
    [Collection("Collection 1")]
    public class SqlProductRepositoryIntegrationTest 
    {
        private string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=ecommerce;User ID=sa;Password=carpond";

        public SqlProductRepositoryIntegrationTest()
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = File.ReadAllText(@"..\..\..\repository\sql\setup.sql");
            cmd.ExecuteNonQuery();
        }

        [Fact]
        public void Create_Product_ShouldAddProduct()
        {
            //arrange
            SqlProductRepository productRepository = new SqlProductRepository(connectionString);
            Product product = new Product("p11", "Hammer", 2.20);
            //act
            bool created = productRepository.Create(product);
            //assert
            Assert.True(created);
            Assert.Contains(product, productRepository.SelectAll());
        }

        [Fact]
        public void SelectAll_Should_Return_All_Products()
        {
            SqlProductRepository productRepository = new SqlProductRepository(connectionString);
            ICollection<Product> products = productRepository.SelectAll();
            Assert.Equal(10, products.Count);
        }

        [Fact]
        public void SelectById_ReturnsMatchingProduct()
        {
            //arrange
            SqlProductRepository productRepository = new SqlProductRepository(connectionString);
            //act
            Product product = productRepository.SelectById("p4");
            //assert
            Assert.Equal("p4", product.Id);
            Assert.Equal("Spaghetti", product.Name);
        }

        [Fact]
        public void Indexer_ReturnsMatchingProduct()
        {
            //arrange
            SqlProductRepository productRepository = new SqlProductRepository(connectionString);
            //act
            Product product = productRepository["p4"];
            //assert
            Assert.Equal("p4", product.Id);
            Assert.Equal("Spaghetti", product.Name);
        }

        [Fact]
        public void Delete_Product_ShouldRemoveProduct()
        {
            //arrange
            SqlProductRepository productRepository = new SqlProductRepository(connectionString);
            //act
            bool deleted = productRepository.Delete("p10");
            //assert
            Assert.True(deleted);
            Assert.DoesNotContain(productRepository.SelectAll(), p => p.Id == "p10");
            Assert.Equal(9, productRepository.SelectAll().Count);
        }

        [Fact]
        public void Delete_ProductNotInDataStore_ShouldReturnFalse()
        {
            //arrange
            SqlProductRepository productRepository = new SqlProductRepository(connectionString);
            //act
            bool deleted = productRepository.Delete("z1");
            //assert
            Assert.False(deleted);
        }

        [Fact]
        public void Update_Product_ShouldUpdateProduct()
        {
            //arrange
            SqlProductRepository productRepository = new SqlProductRepository(connectionString);
            Product product = productRepository.SelectAll().First(p => p.Id == "p1");
            product.CostPrice = 1.6;
            //act            
            bool updated = productRepository.Update(product);
            //assert
            Assert.True(updated);
            Assert.Equal(1.6, productRepository.SelectAll().First(p => p.Id == "p1").CostPrice);
        }

        [Fact]
        public void Update_ContrivedOptimisticConcurrencyConflict()
        {
            //arrange
            SqlProductRepository productRepository = new SqlProductRepository(connectionString);
            Product product1 = productRepository.SelectAll().First(p => p.Id == "p1");
            Product product2 = productRepository.SelectAll().First(p => p.Id == "p1");
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

    }
}
