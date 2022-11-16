
using ConsoleApp1;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyApp
{
    internal class Program
    {
        static void Main(String[] args)
        {
            //DayOfWeek d = DayOfWeek.Wednesday;
            //DateTime dt = new DateTime(2022, 11, 16);
            //Console.WriteLine(dt.DayOfWeek == d);

            Hotel hotel1 = new Hotel();
            hotel1.Id = 1;
            List<Guest> guestList = new List<Guest>();
            Guest guest1 = new Guest();
            guest1.Id = 221;
            guest1.Name = "John Smith";
            guest1.CheckInDate = new DateTime(2022, 11, 20);
            guestList.Add(guest1);
            Guest guest2 = new Guest();
            guest2.Id = 222;
            guest2.Name = "Jane Smith";
            guest2.CheckInDate = new DateTime(2022, 11, 20);
            guestList.Add(guest2);
            hotel1.Guests = guestList;


            //build a Product object
            //build a LineItem object associated with the product
            //build an Order object and add the LineItem to the List of LineItems
            //build an Account object
            //set the Order object's Account property

            //build a 4 element array of type Product
            //Product[] products = new Product[4];
            List<Product> productList= new List<Product>();

            //add two NormalGood objects and two VeblenGood objects to the array
            productList.Add(new  NormalGood(1, "Pedigree Chum", 0.4));
            productList.Add(new NormalGood(2, "Fork", 0.6));
            productList.Add(new VeblenGood(3, "Krug Champagne", 25));
            productList.Add(new VeblenGood(4, "Rolex watch", 700));

            int num = productList.Count;
            Product p = productList[2];

            //arrayList.Add("some text");

            //write a foreach loop to iterate through the array,
            //   displaying the name and retail price of each product

            foreach (Product product in productList)
            {
                Console.WriteLine($"{product.Name} Cost Price {product.CostPrice:C} Retail Price {product.RetailPrice:C} ");
            }


            Product p1 = new NormalGood(1, "Pedigree Chum", 0.4);
            Product p2 = new NormalGood(2, "Fork", 0.6);

            LineItem lineItem1 = new LineItem();
            lineItem1.Id = 1;
            lineItem1.Product = p1;
            lineItem1.Quantity = 4;

            LineItem lineItem2 = new LineItem();
            lineItem1.Id = 3;
            lineItem1.Product = p2;
            lineItem1.Quantity = 2;

            Order order1 = new Order();
            order1.OrderId = 1;
            order1.LineItems.Add(lineItem1);
            order1.LineItems.Add(lineItem2);
            order1.Date= DateTime.Now;
            order1.OrderStatus = OrderStatus.Delivered;

            Account account1 = new Account();
            account1.Id = "1";
            account1.Name = "Dave Dawdson";
            account1.Password = "password";

            order1.Account = account1; 


        }


    }
}