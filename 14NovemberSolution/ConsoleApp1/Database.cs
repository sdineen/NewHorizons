﻿using Microsoft.Data.Sqlite;
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

            SqliteProductRepository productRepository = new SqliteProductRepository();

            foreach (Product product in productRepository.SelectAll())
            {
                Console.WriteLine(product);
            }
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
