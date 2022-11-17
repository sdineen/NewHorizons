using Xunit;
using System.Collections.Generic;
using ClassLibrary.Entity;

namespace ClassLibrary.Test.Entity
{
    public class ProductTest
    {
        [Fact]
        public void Constructor_WhenPassedParameters_ShouldSetProperties()
        {
            Product product = new Product("p1", "Dog's Dinner", 1.20, 2.50);
            Assert.Equal("p1", product.Id);
            Assert.Equal("Dog's Dinner", product.Name);
            Assert.Equal(1.20, product.CostPrice);
            Assert.Equal(2.50, product.RetailPrice);
        }

        [Fact]
        public void ProductsWithSameIdShouldBeEqual()
        {
            //arrange
            Product product1 = new Product { Id = "1" };
            Product product2 = new Product { Id = "1" };
            //act
            bool equal = product1.Equals(product2);
            //assert
            Assert.True(equal);
        }

        [Fact]
        public void ProductsShouldWorkCorrectlyWithList()
        {
            List<Product> products = new List<Product>();
            Product product1 = new Product { Id = "1" };
            Product product2 = new Product { Id = "1" };
            products.Add(product1);
            bool removed = products.Remove(product2);
            Assert.Empty(products);
        }

        [Fact]
        public void ProductsShouldWorkCorrectlyWithHashSet()
        {
            HashSet<Product> products = new HashSet<Product>();
            Product product1 = new Product { Id = "1" };
            Product product2 = new Product { Id = "1" };
            bool added = products.Add(product1);
            bool removed = products.Remove(product2);
            Assert.Empty(products);
        }

        [Fact]
        [Trait("Core.Entities", "Unit Test")]
        public void ProductsWithDifferentIdsShouldBeUnequal()
        {
            //arrange
            Product product1 = new Product { Id = "1" };
            Product product2 = new Product { Id = "2" };
            //act
            bool equal = product1.Equals(product2);
            //assert
            Assert.False(equal);
        }

        [Fact]
        [Trait("Core.Entities", "Unit Test")]
        public void ProductsWithSameIdShouldHaveEqualHashcodes()
        {
            //arrange
            Product product1 = new Product { Id = "1" };
            Product product2 = new Product { Id = "1" };
            //act
            int hashcode1 = product1.GetHashCode();
            int hashcode2 = product2.GetHashCode();
            //assert
            Assert.True(hashcode1 == hashcode2);
        }

        [Fact]
        [Trait("Core.Entities", "Unit Test")]
        public void ProductsWithDiferentIdsShouldHaveUnequalHashcodes()
        {
            //arrange
            Product product1 = new Product { Id = "1" };
            Product product2 = new Product { Id = "2" };
            //act
            int hashcode1 = product1.GetHashCode();
            int hashcode2 = product2.GetHashCode();
            //assert
            Assert.False(hashcode1 == hashcode2);
        }
    }
}
