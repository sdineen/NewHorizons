
using ConsoleApp1;

namespace MyApp
{
    internal class Program
    {
        static void Main(String[] args)
        {
            //acc1 is an object reference variable
            Account acc1 = new Account(); //builds an Account object
            acc1.Name = "Bill"; //sets the name variable of the object
            acc1.Id = "account1";
            acc1.Password = "password";

            Console.WriteLine($"id: {acc1.Id} name: {acc1.Name}");
        }

       
    }
}