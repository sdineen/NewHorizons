using System.Diagnostics;
using ClassLibrary.Entity;
using ClassLibrary.Repository;
using Microsoft.Data.SqlClient;

namespace ClassLibrary.Repository.Sql
{
    public class SqlAccountRepository : IAccountRepository
    {
        private string connectionString;

        public SqlAccountRepository(string connectionString)
            => this.connectionString = connectionString;

        public bool Create(Account account)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "insert into Accounts (id, name, password) values (@id, @name, @password)";
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue("id", account.Id);
            cmd.Parameters.AddWithValue("name", account.Name);
            cmd.Parameters.AddWithValue("password", account.Password);
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

        public Account SelectById(string id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string sql = "select * from accounts where id = @id";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.Read())
            {
                return new Account
                {
                    Id = (string)dataReader["id"],
                    Name = (string)dataReader["name"],
                    Password = (string)dataReader["password"]
                };
            }
            return null;
        }

        public bool Update(Account account)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update accounts set name = @name, password=@password where id = @id";
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue("id", account.Id);
            cmd.Parameters.AddWithValue("name", account.Name);
            cmd.Parameters.AddWithValue("password", account.Password);
            try
            {
                int rowsUpdated = cmd.ExecuteNonQuery();
                return rowsUpdated == 1;
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public bool Delete(string accountId)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete from accounts where id = @id";
            cmd.Parameters.AddWithValue("id", accountId);
            cmd.Connection = connection;
            return cmd.ExecuteNonQuery() == 1;
        }
    }
}