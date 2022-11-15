
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

            //build a Product object
            Product p1 = new Product();
            //set the properties of the object
            p1.Id = 1;
            p1.Name = "Dog food";
            p1.CostPrice= 2.54;
            //display the properties at the console
            Console.WriteLine($"id: {p1.Id} name: {p1.Name} cost price: {p1.CostPrice}");
        }

       
    }
}