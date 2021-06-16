using System;
using context;
using P0DbAndTests;


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using System.Collections.Generic;

namespace P0DbAndTests
{
    class Program
    {


        public static void StartShopping()
        {
            P0DbAndTests.Customer cust = new P0DbAndTests.Customer();
            P0DbAndTests.Order ord = new P0DbAndTests.Order();
            P0DbAndTests.Cart cart = new P0DbAndTests.Cart();
            P0DbAndTests.Messages msg = new Messages();


            Console.WriteLine("Please input START when you would like to start shopping, or LGGOUT if you would like to logout");
            string start = Console.ReadLine();
            //if START
            if (start == "START" || start.ToLower() == "start")
            {
                //StoreSelect method 
                Location.SelectStore();//(incorporates StoreView and StoreInven methods)

                //method to create a cart
                Order.CreateCart();
            }
            //if not START
            if (start == "LOGOUT" || start.ToLower() == "logout")
            {
                Console.WriteLine("You have successfully logged out.");
                Messages.Login();
            }
            if (start == "QUIT" || start.ToLower() == "quit")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Input not recognized.Please input START when you would like to start shopping, or LOGOUT if you would like to logout");
            }
        }

        static void Main(string[] args)
        {
            //instantiates object of "context" type
            context.P0DbContext context = new context.P0DbContext();
            Messages msg = new Messages();
            Location loc = new Location();
            Customer currentCust = new Customer();
            Order ord = new Order();
            Cart cart = new Cart();




            //Opening console UI & welcoming user
            Messages.WelcomeScreen();

            //method to "enter" a store (view store inventory) after user selects a location
            StartShopping();
            //           Location.SelectStore();

            //Shop
            //         Order.CreateCart();

            /*Method to sort customers data
            Customer.SortCustomersFirst();
            Console.WriteLine("\n");
            Customer.SortCustomersMemberStatus();
            */
            Console.WriteLine("\n+Demo: store order history for Tampa.");
            Location.StoreOrderHistory(1);
            Messages.ChooseView();


            /*method to recall all order history for a customer
            Customer.CustomerOrderHistory(1);
            Customer.AllOrderHistory(1);
            */
        }
    }//class
}//namespace
