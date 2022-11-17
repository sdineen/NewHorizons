using ClassLibrary.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using WinClient.Products.Model.Service;
using Xunit;

namespace WinClient.Test.Products.Model
{
    public class RestServiceClientTest
    {
        [Fact]
        public async void SelectByNameAsyncTest()
        {
            //arange
            RestServiceClient client = new RestServiceClient();

            //act
            IEnumerable<Product> products = await client.SelectByNameAsync();

            //assert
            Assert.NotEmpty(products);
        }

        [Fact]
        public void InvalidUriTest()
        {
            //arange
            RestServiceClient client = new RestServiceClient("https://localhost:50000");

            //act
            Assert.ThrowsAsync<HttpRequestException>(async () => await client.SelectByNameAsync());

        }
        [Fact]
        public async void AuthenticationTest()
        {
            //arange
            string username = "acc1";
            string password = "test";
            //act
            RestServiceClient client = new RestServiceClient();
            bool authenticated = await client.Authenticate(username, password);

            await client.AddProductToOrder("p5", username);
            await client.AddProductToOrder("p5", username);
            await client.AddProductToOrder("p6", username);

            Order order = await client.GetBasket(username);

            bool confirmed = await client.ConfirmOrder(username);

            Order emptyOrder = await client.GetBasket(username);

            //assert
            Assert.True(authenticated);
            Assert.Equal(2, order.LineItems.Count);
            Assert.Equal(2, order.LineItems.First(lineItem => lineItem.Product.Id == "p5").Quantity);
            Assert.True(confirmed);
            Assert.Empty(emptyOrder.LineItems);
        }

    }
}
