using Microsoft.Data.Sqlite;
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

            EfProductRepository productRepository = new EfProductRepository(
                new ECommerceContext());

            foreach (var item in  productRepository.SelectAllAsync().Result)
            {
                Console.WriteLine(item);
            }


            //productRepository.Delete(2);


            //Product p = new Product(1, "Pedigree Chum", 0.4, 2.55);
            //productRepository.Update(p);


            //List<Product> productList = new List<Product>();
            //productList.Add(new NormalGood(1, "Pedigree Chum", 0.4));
            //productList.Add(new NormalGood(2, "Fork", 0.6));
            //productList.Add(new VeblenGood(3, "Krug Champagne", 25));
            //productList.Add(new VeblenGood(4, "Rolex watch", 700));

            //foreach (Product product in productList)
            //{
            //    productRepository.Create(product);
            //}


            //foreach (Account account in context.Accounts)
            //{
            //    Console.WriteLine(account.Name);
            //}

            //SqliteProductRepository productRepository = new SqliteProductRepository();

            //foreach (Product product in productRepository.SelectAll())
            //{
            //    Console.WriteLine(product);
            //}
            //Product product = new Product(1, "chair", 22.0, 34.7);
            //productRepository.Create(product);


            //try
            //{
            //    using SqliteConnection connection = new SqliteConnection("Data Source=database.db");
            //    connection.Open();
            //    SqliteCommand cmd = new SqliteCommand();
            //    cmd.Connection = connection;
            //    cmd.CommandText = "create table if not exists accounts(id integer primary key, name text not null, password text not null); ";
            //    bool tableCreated = cmd.ExecuteNonQuery() == 1;
            //    cmd.CommandText = "insert into accounts (name, password)  values('John Smith', 'test'); ";
            //    int rowsInserted = cmd.ExecuteNonQuery();
            //}
            //catch (SqliteException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}




            //SqliteConnection connection = new SqliteConnection("Data Source=database.db");
            //try
            //{
            //    connection.Open();
            //    SqliteCommand cmd = new SqliteCommand();
            //    cmd.Connection = connection;
            //    cmd.CommandText = "create table if not exists accounts(id integer primary key, name text not null, password text not null); ";
            //    bool tableCreated = cmd.ExecuteNonQuery() == 1;
            //    cmd.CommandText = "insert into accounts (name, password)  values('John Smith', 'test'); ";
            //    int rowsInserted = cmd.ExecuteNonQuery();
            //}
            //finally
            //{
            //    connection.Close();
            //}

        }
    }
}
