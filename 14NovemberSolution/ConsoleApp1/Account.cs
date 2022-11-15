using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Account
    {
        //instance variables
        private string? id;
        private string name = "";
        private string? password;

        //properties
        public string? Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string? Password
        {
            get { return password; }
            set { password = value; }
        }



    }
}
