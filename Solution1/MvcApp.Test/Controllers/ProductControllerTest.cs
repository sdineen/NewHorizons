using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using ClassLibrary.Entity;
using MvcApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ClassLibrary.Service;

namespace MvcApp.Test.Controllers
{
    //https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing
    public class ProductControllerTest
    {
        ICollection<Product> products = new List<Product> {
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
            };

        [Fact]
        public async Task Index_ReturnsAViewResult_WithACollectionOfProducts()
        {
            // Arrange
            Mock<IEcommerceService> mockService = new Mock<IEcommerceService>();
            mockService.Setup(svc => svc.SelectProductsAsync(null))
                .Returns(Task.FromResult(products));
            ProductController controller = new ProductController(mockService.Object, null);

            // Act
            ViewResult result = await controller.Index() as ViewResult;

            // Assert
            IEnumerable<Product> model = Assert.IsAssignableFrom<IEnumerable<Product>>(result.Model);
            Assert.Equal(10, model.Count());
        }

        /// <summary>
        /// This passes a mock of IHttpContextAccessor into the controller's constructor
        /// This avoids a null pointer exception caused by calling User.Identity.Name in the controller
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task AddProduct_ReturnsAViewResult_WithACollectionOfLineItems()
        {
            // Arrange
            Mock<Order> mockOrder = new Mock<Order>();
            mockOrder.Setup(o => o.LineItems).Returns(new List<LineItem>());

            Mock<IEcommerceService> mockService = new Mock<IEcommerceService>();
            mockService.Setup(svc => svc.AddProductToOrderAsync("p1", "user1")).Returns(Task.FromResult(mockOrder.Object));

            Mock<IHttpContextAccessor> mockContext = new Mock<IHttpContextAccessor>();
            mockContext.Setup(c => c.HttpContext.User.Identity.Name).Returns("user1");

            ProductController controller = new ProductController(mockService.Object, mockContext.Object);

            // Act
            ViewResult result = await controller.AddProduct("p1") as ViewResult;

            // Assert
            Assert.Equal("Basket", result.ViewName);
            Assert.IsAssignableFrom<IEnumerable<LineItem>>(result.Model);
        }
    }
}
