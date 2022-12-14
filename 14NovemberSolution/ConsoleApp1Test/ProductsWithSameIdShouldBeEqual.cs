using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1Test
{
    public class ProductTest
    {
        [Fact]
        public void ProductsWithSameIdShouldBeEqual()
        {
            //arrange
            Product product1 = new Product { Id = 1 };
            Product product2 = new Product { Id = 1 };
            //act
            bool equal = product1.Equals(product2);
            //assert
            Assert.True(equal);
        }

        [Fact]
        public void ProductsShouldWorkCorrectlyWithList()
        {
            List<Product> products = new List<Product>();
            Product product1 = new Product { Id = 1 };
            Product product2 = new Product { Id = 1 };
            products.Add(product1);
            bool removed = products.Remove(product2);
            Assert.Empty(products);
        }

        [Fact]
        public void ProductsShouldWorkCorrectlyWithHashSet()
        {
            HashSet<Product> products = new HashSet<Product>();
            Product product1 = new Product { Id = 1 };
            Product product2 = new Product { Id = 1 };
            products.Add(product1);
            bool removed = products.Remove(product2);
            Assert.Empty(products);
        }


    }
}
