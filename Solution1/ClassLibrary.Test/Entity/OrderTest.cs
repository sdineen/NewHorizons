using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ClassLibrary.Test.Entity
{
    public class OrderTest
    {
        [Fact]
        public void AddProduct_WhenCalledTwiceWithDifferentProducts_ShouldAddTwoLineItems()
        {
            //arrange
            Order order = new Order();
            Product product1 = new Product("p1", "Dog Dinner", 1.20);
            Product product2 = new Product("p2", "Fork", 2.20);
            //act
            order.AddProduct(product1, 2);
            order.AddProduct(product2, 4);
            //assert
            Assert.NotNull(order.LineItems);
            Assert.Equal(2, order.LineItems.Count);
            Assert.Equal(4, order.LineItems.First(li=>li.Product.Id=="p2").Quantity);
        }

        [Fact]
        public void AddProduct_WhenCalledTwiceWithSameProduct_ShouldIncrementLineItemQuantity()
        {
            //arrange
            Order order = new Order();
            Product product1 = new Product("p1", "Dog Dinner", 1.20);
            Product product2 = new Product("p1", "Dog Dinner", 1.20);
            //act
            order.AddProduct(product1, 2);
            order.AddProduct(product2, 2);
            //assert
            Assert.NotNull(order.LineItems);
            Assert.Single(order.LineItems);
            Assert.Equal(4, order.LineItems.First().Quantity);
            Assert.True(order.LineItems.All(li => li.Product.Id == "p1"));
        }

        [Fact]
        public void RemoveLineItem_WhenPassedProduct_ShouldRemoveLineItemContainingTheProduct()
        {
            //arrange
            Order order = new Order();
            Product product1 = new Product("p1", "Dog Dinner", 1.20);
            Product product2 = new Product("p2", "Fork", 2.20);
            order.LineItems = new List<LineItem> { 
                new LineItem { Product = product1, Quantity = 2 },
                new LineItem { Product = product2, Quantity = 4 }
            };

            //act
            bool removed = order.RemoveLineItem(product1);
            //assert
            Assert.True(removed);
            Assert.Single(order.LineItems);
        }
     
    }
}
