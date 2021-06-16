using System;
using P0DbContext;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using System.Collections.Generic;

namespace P0DbAndTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiates object of "context" type
            P0DbContext.P0DbContext context = new P0DbContext.P0DbContext();
            Messages msg = new Messages();
            Location loc = new Location();
            Customer currentCust = new Customer();
            //0

            //Opening console UI & welcoming user
            // Messages.WelcomeScreen();
            Messages.Login();
            //method to "enter" a store (view store inventory) after user selects a location
            Location.SelectStore();

            //Add Items to cart

            //its simple to query the context

            //Method to sort customers data
            Customer.SortCustomersFirst();
            Customer.SortCustomersMemberStatus();

            //method to recall all order history for a customer
            Customer.CustomerOrderHistory(3);
        }
    }//class
}//namespace
