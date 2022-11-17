using ClassLibrary.Entity;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using System;
using Moq;
using ClassLibrary.Repository;
using ClassLibrary.Repository.EF;
using ClassLibrary.Service;

namespace ClassLibrary.Test.Service
{
    public class EcommerceServiceUnitTest
    {
        [Fact]
        public async void AddProductToOrderAsyncTest()
        {
            //arrange
            //1. build mock dependencies
            Mock<IProductRepositoryAsync> productRepository = new Mock<IProductRepositoryAsync>();
            Mock<IOrderRepositoryAsync> orderRepository = new Mock<IOrderRepositoryAsync>();
            Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();       

            //2. set up mock dependencies
            //setup productRepository so that its SelectByIdAsync method returns a Product
            Product product = new Product("p1", "Pedigree Chum", 0.70, 1.42);
            productRepository.Setup(p => p.SelectByIdAsync("p1")).Returns(Task.FromResult<Product>(product));

            //setup accountRepository so that its SelectById method returns an Account
            Account account = new Account("acc1", "John Smith", "test");
            accountRepository.Setup(a => a.SelectById("acc1")).Returns(account);

            //setup orderRepository so that its SelectProvisionalOrderByAccountIdAsync method returns a mock Order
            Mock<Order> mockOrder = new Mock<Order>();
            mockOrder.Setup(o => o.LineItems).Returns(new List<LineItem> { new LineItem { Product = product } });
            orderRepository.Setup(o => o.SelectProvisionalOrderByAccountIdAsync("acc1")).Returns(Task.FromResult<Order>(mockOrder.Object));

            //3. build SUT
            EcommerceService service = new EcommerceService(
                accountRepository.Object,
                productRepository.Object,
                orderRepository.Object);
            //act
            Order order = await service.AddProductToOrderAsync("p1", "acc1");

            //assert
            Assert.Equal(product, order.LineItems.Single(li => li.Product.Id == "p1").Product);
            orderRepository.Verify(or => or.UpdateAsync(order));
        }

        [Fact]
        public async void SelectProductAsync_WhenPassedString_CallsSelectByNameAsyncMethodOfIProductRepositoryAsync()
        {
            //arrange
            Mock<IProductRepositoryAsync> productRepository = new Mock<IProductRepositoryAsync>();
            ICollection<Product> products = new List<Product> {
                new Product("p1", "Pedigree Chum", 0.70, 1.42),
                new Product("p2", "Knife", 0.60, 1.31)
            };
            productRepository.Setup(repo => repo.SelectByNameAsync("e"))
                .Returns(Task.FromResult(products));
            EcommerceService service = new EcommerceService(null, productRepository.Object, null);

            //act
            ICollection<Product> result = await service.SelectProductsAsync("e");

            //assert
            productRepository.Verify(repo => repo.SelectByNameAsync("e"));
            Assert.Equal(products, result);
        }

        [Fact]
        public async void SelectProductAsync_WhenNotPassedString_CallsSelectAllAsyncMethodOfIProductRepositoryAsync()
        {
            //arrange
            Mock<IProductRepositoryAsync> productRepository = new Mock<IProductRepositoryAsync>();
            EcommerceService service = new EcommerceService(null, productRepository.Object, null) ;

            //act
            await service.SelectProductsAsync();

            //assert
            productRepository.Verify(repo => repo.SelectAllAsync());
        }

        [Fact]
        public async void SelectOrderAsync_Calls_SelectByOrderIdAsync_Method_Of_IOrderRepositoryAsync()
        {
            //arrange
            var orderRepository = new Mock<IOrderRepositoryAsync>();
            EcommerceService service = new EcommerceService(null, null, orderRepository.Object);

            //act
            await service.SelectOrderAsync(1);

            //assert
            orderRepository.Verify(repo => repo.SelectByOrderIdAsync(1));
        }

        [Fact]
        public async void ConfirmOrderAsync_WhenPassedAccountIdWithNoProvisionalOrder_ThrowsInvalidOperationException()
        {
            //arrange
            Mock<IOrderRepositoryAsync> orderRepository = new Mock<IOrderRepositoryAsync>();
            Order order = null;
            orderRepository.Setup(or => or.SelectProvisionalOrderByAccountIdAsync(It.IsAny<string>())).Returns(Task.FromResult(order));
            EcommerceService service = new EcommerceService(null, null, orderRepository.Object);

            //act
            //assert
            await Assert.ThrowsAsync<InvalidOperationException>(()=>service.ConfirmOrderAsync("acc1"));
        }
    }
}
