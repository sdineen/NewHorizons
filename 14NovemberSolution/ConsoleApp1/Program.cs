
using ConsoleApp1;

namespace MyApp
{
    internal class Program
    {
        static void Main(String[] args)
        {
            Coords c1 = new Coords(12,20);
            Console.WriteLine(c1.X);
            Console.WriteLine(c1.Y);

            //acc1 is an object reference variable
            Account acc1 = new Account(); //builds an Account object
            acc1.Name = "Bill"; //sets the name variable of the object
            acc1.Id = "account1";
            acc1.Password = "password";

            Console.WriteLine($"id: {acc1.Id} name: {acc1.Name}");

            Account acc2 = new Account("account2", "Dave", "pwd2");

            //build a Product object
            NormalGood p1 = new NormalGood();
            //set the properties of the object
            p1.Id = 1;
            p1.Name = "Dog food";
            p1.CostPrice= 2.54;
            //p1.RetailPrice = 3.71;
            //display the properties at the console
            //Console.WriteLine($"id: {p1.Id} name: {p1.Name} cost price: {p1.CostPrice} retail price: {p1.RetailPrice}");

            NormalGood p2 = new NormalGood(2, "Knife", 0.65);
            Console.WriteLine($"id: {p2.Id} name: {p2.Name} cost price: {p2.CostPrice} retail price: {p2.RetailPrice}");


            VeblenGood v1 = new VeblenGood();
            v1.Id = 3;
            v1.Name = "Rolex";
            v1.CostPrice= 500;

            VeblenGood v2 = new VeblenGood(4, "Gucci handbag", 500);

            Console.WriteLine($"id: {v2.Id} name: {v2.Name} cost price: {v2.CostPrice} retail price: {v2.RetailPrice}");


        }


    }
}