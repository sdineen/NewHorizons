using ClassLibrary.Entity;
using ClassLibrary.Repository.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ClassLibrary.Test.Repository.EF
{
    public class OrderRepositoryUnitTest
    {
        protected EcommerceContext context;
        public OrderRepositoryUnitTest()
        {
            string connectionString = @"Data Source=.\sqlexpress;Initial Catalog = test; User ID = sa; Password = carpond; ConnectRetryCount=0";
            context = new EcommerceContext(new DbContextOptionsBuilder<EcommerceContext>()
                              .UseSqlServer(connectionString)
                              .Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            CreateOrder();
        }

        ~OrderRepositoryUnitTest() => context.Dispose();

        [Fact]
        public async void SelectProvisionalOrderByAccountIdAsync_RetrievesOrderWithPopulatedProperties()
        {
            //arrange
            CreateOrder();
            OrderRepository orderRepository = new OrderRepository(context);

            //act
            Order order = await orderRepository.SelectProvisionalOrderByAccountIdAsync("acc1");

            //assert
            Assert.Equal("Pedigree Chum", order.LineItems.First(li => li.Product.Id == "p1").Product.Name);
            Assert.Equal("John Smith", order.Account.Name);
        }

        [Fact]
        public async void UpdateAsync_WhenPassedModifiedOrder_UpdatesOrderTable()
        {
            //arrange
            Order order = CreateOrder();
            order.OrderStatus = OrderStatus.Confirmed;
            OrderRepository orderRepository = new OrderRepository(context);

            //act
            bool updated = await orderRepository.UpdateAsync(order);

            //assert
            Assert.Equal(OrderStatus.Confirmed, context.Orders.Find(order.OrderId).OrderStatus);
        }

        [Fact]
        public async void DeleteTestAsync()
        {
            //arrange
            Order order = CreateOrder();
            var orderRepository = new OrderRepository(context);

            //act
            bool deleted = await orderRepository.DeleteAsync(order.OrderId);

            //assert
            Assert.Null(context.Orders.Find(order.OrderId));
        }

        [Fact]
        public async void Create_DuplicateOrder_ThrowsInvalidOperationException()
        {
            //arrange
            CreateOrder();
            var orderRepository = new OrderRepository(context);
            Order order2 = new Order
            {
                AccountId = "acc1",
                OrderStatus = OrderStatus.Provisional
            };

            //assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => orderRepository.CreateAsync(order2));
        }


        [Fact]
        public async void SelectOrdersByAccountIdAsyncTest()
        {
            //arrange
            CreateOrder();
            OrderRepository orderRepository = new OrderRepository(context);

            //act
            ICollection<Order> orders =
                await orderRepository.SelectOrdersByAccountIdAsync("acc1");

            //assert
            Assert.Equal("Pedigree Chum", orders.First().LineItems.First().Product.Name);
        }

        private Order CreateOrder()
        {
            Order provisionalOrder = new Order
            {
                AccountId = "acc1",
                OrderStatus = OrderStatus.Provisional,
                LineItems = new List<LineItem>
                {
                    new LineItem { ProductId ="p1", Quantity = 2,},
                    new LineItem { ProductId ="p2", Quantity = 1 }
                }
            };
            context.Orders.Add(provisionalOrder);
            context.SaveChanges();
            return provisionalOrder;
        }
    }
}
