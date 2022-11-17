using ClassLibrary.Entity;
using ClassLibrary.Repository.JSON;
using System.IO;
using Xunit;

namespace ClassLibrary.Test.Repository.Json
{
    public class BinaryProductRepositoryIntegrationTest
    {
        [Fact]
        public void BinarySerializationTest()
        {
            //arrange
            string path = @"C:\Users\Public\Documents\products.bin";
            File.Delete(path); //If the file to be deleted does not exist, no exception is thrown.
            ProductRepository productRepository = new ProductRepository(new BinaryProductSerializer());

            Product product1 = new Product("p1", "Pedigree Chum", 0.70, 1.42);
            Product product2 = new Product("p2", "Knife", 0.60, 1.31);
            Product product3 = new Product("p3", "Fork", 0.75, 1.57);
            Product product4 = new Product("p4", "Spaghetti", 0.90, 1.92);

            bool created1 = productRepository.Create(product1);
            bool created2 = productRepository.Create(product2);
            bool created3 = productRepository.Create(product3);
            bool created4 = productRepository.Create(product4);

            bool deleted = productRepository.Delete("p4");

            product3.RetailPrice = 2;
            bool updated = productRepository.Update(product3);

            //deserializes product collection
            productRepository = new ProductRepository(new BinaryProductSerializer());
            //assert
            Assert.True(productRepository.SelectAll().Contains(product1));
            Assert.Equal(3, productRepository.SelectAll().Count);
            Assert.Equal(2, product3.RetailPrice);
        }
    }
}
