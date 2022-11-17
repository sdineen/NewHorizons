using ClassLibrary.Entity;
using ClassLibrary.Repository;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace ClassLibrary.Repository.Sql
{
    public class SqlProductRepository : IProductRepository
    {
        private string connectionString;

        public SqlProductRepository(string connectionString)
            => this.connectionString = connectionString;

        /// <summary>
        /// Adds a new product to the data store
        /// </summary>
        /// <param name="product"></param>
        /// <returns>false if the product already exists</returns>
        public bool Create(Product product)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into Products (id, name, costPrice, retailPrice) values (@id, @name, @costPrice, @retailPrice)";
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue("id", product.Id);
            cmd.Parameters.AddWithValue("name", product.Name);
            cmd.Parameters.AddWithValue("costPrice", product.CostPrice);
            cmd.Parameters.AddWithValue("retailPrice", product.RetailPrice);
            try
            {
                return cmd.ExecuteNonQuery() == 1;
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public bool Delete(string id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete from products where id = @id";
            cmd.Parameters.AddWithValue("id", id);
            cmd.Connection = connection;
            return cmd.ExecuteNonQuery() == 1;
        }

        public ICollection<Product> SelectAll()
        {
            ICollection<Product> products = new List<Product>();
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string sql = "select * from products";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                products.Add(
                    new Product
                    {
                        Id = (string)dataReader["id"],
                        Name = (string)dataReader["name"],
                        CostPrice = (double)dataReader["costPrice"],
                        RetailPrice = (double)dataReader["retailPrice"],
                        RowVersion = (byte[])dataReader["rowVersion"]
                    }
                );
            }
            return products;
        }

        /// <summary>
        /// retrieves a Product
        /// </summary>
        /// <param name="id">the product's unique key</param>
        /// <returns></returns>
        public Product SelectById(string id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string sql = "select * from products where id = @id";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("id", id);
            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.Read())
            {
                return new Product
                {
                    Id = (string)dataReader["id"],
                    Name = (string)dataReader["name"],
                    CostPrice = (double)dataReader["costPrice"],
                    RetailPrice = (double)dataReader["retailPrice"],
                    RowVersion = (byte[])dataReader["rowVersion"]
                };
            }
            return null;
        }

        //read only indexer implemented as expression-bodied member
        public Product this[string index] { get => SelectById(index); }

        public bool Update(Product product)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using SqlCommand cmd = new SqlCommand();
            SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.Serializable);
            cmd.Transaction = transaction;
            cmd.CommandText = "update products set name = @name, costPrice = @costPrice, retailPrice = @retailPrice where id = @id and [RowVersion] = @rowVersion";
            cmd.Connection = connection as SqlConnection;
            cmd.Parameters.AddWithValue("id", product.Id);
            cmd.Parameters.AddWithValue("name", product.Name);
            cmd.Parameters.AddWithValue("costPrice", product.CostPrice);
            cmd.Parameters.AddWithValue("retailPrice", product.RetailPrice);
            cmd.Parameters.AddWithValue("rowVersion", product.RowVersion);
            try
            {
                int rowsUpdated = cmd.ExecuteNonQuery();
                transaction.Commit();
                return rowsUpdated == 1;
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e);
                transaction.Rollback(); //can throw an Exception
                return false;
            }

        }
    }
}
