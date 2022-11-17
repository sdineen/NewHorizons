using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Examples.Security
{
    public class Hashing
    {
        public static void Main()
        {
            string password1 = "test";
            string password2 = "test";
            Console.WriteLine($"password1 hash is {GetHash(password1)} ");
            Console.WriteLine($"password2 hash is {GetHash(password2)} ");
        }
        private static string GetHash(string input)
        {
            using SHA256 hashAlgorithm = SHA256.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] hashBytes = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
            //BitConverter.ToString returns a string of hexadecimal pairs separated by hyphens
            return BitConverter.ToString(hashBytes).Replace("-", String.Empty);
        }



    }
}
