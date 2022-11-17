﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace ClassLibrary.Entity
{
    [Serializable]
    public class Account
    {
        //instance variables
        private string id;
        private string name;
        private string password;

        //property
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        //expression-bodied property
        public string Name { get => name; set => name = value; }

        public string Password
        {
            get => password; //returns hash
            set => password = GetHash(value); //converts value into hash            
        }

        /// <summary>
        /// Compares hashed passwords
        /// </summary>
        /// <param name="password">plain text password</param>
        /// <returns>true if hashed passwords are equal</returns>
        public bool IsAuthenticated(string password) => Password == GetHash(password);

        /// <summary>
        /// converts string to SHA256 hash
        /// </summary>
        //https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.hashalgorithm.computehash?view=netcore-3.1
        //https://md5decrypt.net/en/Sha256/
        private static string GetHash(string input)
        {
            using SHA256 hashAlgorithm = SHA256.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] hashBytes = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
            //BitConverter.ToString returns a string of hexadecimal pairs separated by hyphens
            return BitConverter.ToString(hashBytes).Replace("-", String.Empty);
        }

        public Account(string id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
        }
        public Account()
        {
        }

        public override string ToString()
        {
            return Id + " " + Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Account ? (obj as Account).Id == Id : false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
