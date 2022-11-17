﻿using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SqliteProductRepository : IProductRepository
    {
        private string connectionString = "Data Source=database.db";
        public bool Create(Product product)
        {
            using SqliteConnection connection = new SqliteConnection(connectionString);
            connection.Open();
            SqliteCommand cmd = new SqliteCommand();

            cmd.CommandText = "insert into Products (name, costPrice, retailPrice) values (@name, @costPrice, @retailPrice)";
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue("name", product.Name);
            cmd.Parameters.AddWithValue("costPrice", product.CostPrice);
            cmd.Parameters.AddWithValue("retailPrice", product.RetailPrice);
            return cmd.ExecuteNonQuery() == 1;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Product>? SelectAll()
        {
            throw new NotImplementedException();
        }

        public Product? SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
