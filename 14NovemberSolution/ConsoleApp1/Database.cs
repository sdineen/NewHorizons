using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Database
    {
        static void Main(string[] args)
        {
            SqliteConnection connection = new SqliteConnection("Data Source=database.db");
            connection.Open();
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = connection;
            cmd.CommandText = "create table if not exists accounts(id integer primary key, name text not null, password text not null); ";
            bool tableCreated = cmd.ExecuteNonQuery() == 1;
            cmd.CommandText = "insert into accounts (name, password)  values('John Smith', 'test'); ";
            int rowsInserted = cmd.ExecuteNonQuery();
            connection.Close();

        }
    }
}
