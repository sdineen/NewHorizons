using ClassLibrary.Entity;
using ClassLibrary.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ReactApp.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ReactApp.Test.Controllers
{
    public class ProductControllerTest
    {
        [Fact]
        public async Task GetByNameAsync_ReturnsOkResult_WithACollectionOfProducts()
        {
            // Arrange
            var mockService = new Mock<IEcommerceService>();
            mockService.Setup(service => service.SelectProductsAsync(null)).ReturnsAsync(products);
            var controller = new ProductController(mockService.Object);

            // Act
            IActionResult result = await controller.GetByNameAsync(null);
            OkObjectResult okResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.True(okResult is OkObjectResult);
            Assert.IsType<List<Product>>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        private ICollection<Product> products = new List<Product> {
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
        
    }
}
