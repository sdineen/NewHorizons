using ClassLibrary.Entity;
using ClassLibrary.Repository.Sql;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;
using Xunit;

namespace ClassLibrary.Test.Repository.Sql
{
    [Collection("Collection 1")]
    public class OrderRepositoryIntegrationTest
    {
        private string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=ecommerce;User ID=sa;Password=carpond";

        public OrderRepositoryIntegrationTest()
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = File.ReadAllText(@"..\..\..\repository\sql\setup.sql");
            cmd.ExecuteNonQuery();
        }
        [Fact]
        public void Create_ReturnsGeneratedOrderId()
        {
            var orderRepository = new SqlOrderRepository(connectionString);
            Order order = new Order { AccountId = "acc1" };
            int orderId1 = orderRepository.Create(order);
            int orderId2 = orderRepository.Create(order);
            Assert.True(orderId2 > orderId1);
        }
    }
}
