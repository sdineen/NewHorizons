//System.Net.Http.Json prerelease package
using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using WinClient.Products.Model.DTO;

/// <summary>
/// </summary>
namespace WinClient.Products.Model.Service
{
    public class RestServiceClient : IRestServiceClient
    {
        private string uri;
        private UserParameters userParameters;

        public RestServiceClient(string uri = "https://sdineen.uk") => this.uri = uri;

        /// <summary>
        /// HTTP GET request to GetByNameAsync method of ProductController
        /// </summary>
        /// <param name="name">part of product name</param>
        /// <returns>ICollection of Products</returns>
        /// <exception>HttpRequestException</exception>
        public async Task<IEnumerable<Product>> SelectByNameAsync(string name = null)
        {
            using HttpClient client = new HttpClient();
            try
            {
                return await client.GetFromJsonAsync<IEnumerable<Product>>(uri + "/api/product/" + name);
            }
            catch (HttpRequestException) // Non success
            {
                Console.WriteLine("An error occurred.");
            }
            catch (NotSupportedException) // When content type is not valid
            {
                Console.WriteLine("The content type is not supported.");
            }
            catch (JsonException) // Invalid JSON
            {
                Console.WriteLine("Invalid JSON.");
            }
            return null;
        }
   
        /// <summary>
        /// Set the JWT token property of the ParameterModel instance variable, which is passed by authenticated users in requests to methods annotated with [Authorize]
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>true if authenticated</returns>
        /// <exception cref="https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httprequestexception?view=netcore-3.1">HttpRequestException</exception>
        public async Task<bool> Authenticate(string username, string password)
        {
            userParameters = new UserParameters { Username = username, Password = password };
            using HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.PostAsJsonAsync(
                uri + "/api/account/authenticate",
                userParameters);

            userParameters = await response.Content.ReadFromJsonAsync<UserParameters>();
            return userParameters.Token != null;
        }
      
        /// <summary>
        //  POST request to AddProduct. JWT token sent in HTTP header
        /// </summary>
        /// <returns>Provisional order</returns>
        /// <exception>HttpRequestException</exception>
        public async Task<Order> AddProductToOrder(string productId, string username)
        {
            using HttpClient client = new HttpClient();            
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + userParameters.Token);
            userParameters.ProductId = productId;
            HttpResponseMessage response =
                await client.PostAsJsonAsync(uri + "/api/order", userParameters);
            return await response.Content.ReadFromJsonAsync<Order>();
        }
  
        /// <summary>
        /// GET request. JWT token sent in HTTP header
        /// </summary>
        /// <param name="username">HTTP request parameter</param>
        /// <returns>Provisional order</returns>
        /// <exception>HttpRequestException</exception>
        public async Task<Order> GetBasket(string username)
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + userParameters.Token);
            return await client.GetFromJsonAsync<Order>(uri + "/api/order/" + username);
        }

        /// <summary>
        /// PUT Request
        /// </summary>
        /// <param name="username">HTTP request parameter</param>
        /// <exception>HttpRequestException</exception>
        public async Task<bool> ConfirmOrder(string username)
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + userParameters.Token);
            HttpResponseMessage response = 
                await client.PutAsync(uri + "/api/order/" + username, null);
            return response.IsSuccessStatusCode;            
        }
    }
}







/*
 using ClassLibrary.Entity;
using Newtonsoft.Json;
using WinClient.Products.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

/// <summary>
/// Microsoft.AspNet.WebApi.Client
/// Newtonsoft.Json
/// </summary>
/// 

namespace WinClient.Products.Model.Service
{
    public class RestServiceClient : IRestServiceClient
    {
        private string uri;
        private UserParameters userParameters;

        public RestServiceClient(string uri = "https://sdineen.uk") =>this.uri = uri;

        /// <summary>
        /// HTTP GET request to GetByNameAsync method of ProductController
        /// </summary>
        /// <param name="name">part of product name</param>
        /// <returns>ICollection of Products</returns>
        /// <exception>HttpRequestException</exception>
        public async Task<ICollection<Product>> SelectByNameAsync(string name = null)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(uri + "/api/product/" + name);
            IEnumerable<Product> products =
                await response.Content.ReadAsAsync<IEnumerable<Product>>();
            return products.ToList();
        }

        /// <summary>
        /// Set the JWT token property of the ParameterModel instance variable, which is passed by authenticated users in requests to methods annotated with [Authorize]
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>true if authenticated</returns>
        /// <exception cref="https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httprequestexception?view=netcore-3.1">HttpRequestException</exception>
        public async Task<bool> Authenticate(string username, string password)
        {
            userParameters = new UserParameters { Username = username, Password = password };
            using HttpClient client = new HttpClient();
            //Send the product, encoded as JSON, in a POST request to the specified Uri 
            string authenticateUri = uri + "/api/account/authenticate";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                authenticateUri,
                userParameters).ConfigureAwait(false);
            userParameters = await response.Content.ReadAsAsync<UserParameters>();
            return userParameters.Token != null;
        }
     
        /// <summary>
        //  POST request to AddProduct. JWT token sent in HTTP header
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="username"></param>
        /// <returns>Provisional order</returns>
        /// <exception>HttpRequestException</exception>
        public async Task<Order> AddProductToOrder(string productId, string username)
        {
            userParameters.ProductId = productId;
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + userParameters.Token);
            //Send the product, encoded as JSON, in a POST request to the specified Uri 
            HttpResponseMessage response = await client.PostAsJsonAsync(
                uri + "/api/order", userParameters).ConfigureAwait(false);
            string json = await response.Content.ReadAsStringAsync();
            //ReadAsAsync doesn't populate LineItems 
            return JsonConvert.DeserializeObject<Order>(json);
        }

        /// <summary>
        /// GET request. JWT token sent in HTTP header
        /// </summary>
        /// <param name="username">HTTP request parameter</param>
        /// <returns>Provisional order</returns>
        /// <exception>HttpRequestException</exception>
        public async Task<Order> GetBasket(string username)
        {
            using HttpClient client = new HttpClient();
            
            //include the JWT in the request header
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + userParameters.Token);
            //Send the product, encoded as JSON, in a GET request to the specified Uri 
            HttpResponseMessage response = await client.GetAsync(
                uri + "/api/order/" + username).ConfigureAwait(false);
            string json = await response.Content.ReadAsStringAsync();
            //var obj = await response.Content.ReadAsAsync<Order>();
            //ReadAsAsync doesn't populate LineItems 
            return JsonConvert.DeserializeObject<Order>(json);
        }

        /// <summary>
        /// PUT Request
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        /// <exception>HttpRequestException</exception>
        public async Task<bool> ConfirmOrder(string username)
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + userParameters.Token);
            HttpResponseMessage response = await client.PutAsync(
                uri + "/api/order/" + username, null).ConfigureAwait(false);

            return response.IsSuccessStatusCode;            
        }
    }
}


*/
