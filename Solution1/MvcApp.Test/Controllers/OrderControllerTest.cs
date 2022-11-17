using ClassLibrary.Entity;
using ClassLibrary.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvcApp.Controllers;
using Xunit;

namespace MvcApp.Test.Controllers
{
    //https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing
    public class OrderControllerTest
    {
        /// <summary>
        /// This passes a mock of IHttpContextAccessor into the controller's constructor
        /// This avoids a null pointer exception caused by calling User.Identity.Name in the controller
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Index_ReturnsAViewResult_WithACollectionOfOrders()
        {
            // Arrange
            ICollection<Order> orders = new List<Order>();
            Mock<IEcommerceService> mockService = new Mock<IEcommerceService>();
            mockService.Setup(svc => svc.SelectOrdersByAccountIdAsync("user1")).Returns(Task.FromResult(orders));

            Mock<IHttpContextAccessor> mockContext = new Mock<IHttpContextAccessor>();
            mockContext.Setup(c => c.HttpContext.User.Identity.Name).Returns("user1");

            OrderController controller = new OrderController(mockService.Object, mockContext.Object);

            // Act
            ViewResult result = await controller.Index() as ViewResult;

            // Assert
            Assert.IsAssignableFrom<ICollection<Order>>(result.Model);
        }


    
    }
}
