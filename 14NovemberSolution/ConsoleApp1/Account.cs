using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Account
    {
        //instance variables
        private string? id;
        private string? name;
        private string? password;

        public Account() 
        {
        }

        public Account(string id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
        }

        //properties

        //expression bodied property
        public string? Name 
        { 
            get => name; 
            set => name = value;
        }

        public string? Id { get => id; set => id = value; }

        //public string? Id
        //{
        //    get { return id; }
        //    set { id = value; }
        //}


        public string? Password
        {
            get { return password; }
            set { password = value; }
        }


    }
}
