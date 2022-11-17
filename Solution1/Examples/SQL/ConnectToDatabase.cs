using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Examples.SQL
{
    public class ConnectToDatabase
    {
        public static void Main()
        {
            string connectionString = "Data Source=.\\sqlexpress;Initial Catalog = ecommerce; User ID = sa; Password = carpond";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "insert into accounts (id, name, password) values ('acc1', 'John Smith', 'test'); ";
            int rowsInserted = cmd.ExecuteNonQuery();
            connection.Close();
        }


        public static void WithTransactions()
        {
            string connectionString = "Data Source=.\\sqlexpress;Initial Catalog = ecommerce; User ID = sa; Password = carpond";
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.Serializable);
            cmd.Connection = connection;
            cmd.Transaction = transaction;
            try
            {
                //valid expression
                cmd.CommandText = "insert into accounts (id, name) values('acc17', 'John Smith'); ";
                int rowsInserted = cmd.ExecuteNonQuery();
                //invalid expression
                cmd.CommandText = "update account set name = 'Jane Smith' where id = 'acc17'; ";
                int rowsUpdated = cmd.ExecuteNonQuery();
                transaction.Commit();
                Console.WriteLine($"updated");
            }
            catch (SqlException e)
            {
                transaction.Rollback();
                Console.WriteLine(e.Message);
            }
        }

    }
}
