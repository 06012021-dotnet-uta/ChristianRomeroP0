using System;
using System.Collections.Generic;
using System.Linq;

namespace P0DbAndTests
{
	public class Customer : ICustomer
	{
		public string FName { get; set; }
		public string LName { get; set; }
		public int Age { get; set; }
		public string Username { get; set; }
		public string Password { get; }
        public int Member { get; set; }
		public string Mailing{ get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }


        //method to sort for customers by first name
        public static void SortCustomersFirst()
        {
            //
            P0DbContext.P0DbContext context = new P0DbContext.P0DbContext();
            using (context)
            {
                //create an ordered list of context type Customer via lambda
                List<P0DbContext.Customer> namedList = context.Customers.OrderBy(b => b.Fname).ToList();
                Console.WriteLine("All customers and basic information, ordered by first name.");
                foreach (var cust in namedList)//output basic information
                {
                    Console.WriteLine($"Name: {cust.Fname} {cust.Lname}  -  Email: {cust.Email}  - " +
                        $"Address: {cust.Mailing} {cust.State},{cust.State} {cust.Zip}");
                }
            }
        }

        public static void SortCustomersMemberStatus()
        {
            P0DbContext.P0DbContext context = new P0DbContext.P0DbContext();
            using (context)
            {
                //create an ordered list of context type Customer via lambda
                List<P0DbContext.Customer> memberList = context.Customers.OrderBy(b => b.Member).ToList();
                Console.WriteLine("All customers and basic information, with members first.");
                foreach (var cust in memberList)//output basic information
                {
                    Console.WriteLine($"Name: {cust.Fname} {cust.Lname}  - Member:{cust.Member}   Email: {cust.Email}  - " +
                        $"Address: {cust.Mailing} {cust.State},{cust.State} {cust.Zip}");
                }
            }
        }

        public static void CustomerOrderHistory(int customerId)
        {
            P0DbContext.P0DbContext context = new P0DbContext.P0DbContext();
            using (context)
            {
                //select star
                List<P0DbContext.Order> history = context.Orders.OrderBy(b => b.CustomerId == customerId).ToList();
                Console.WriteLine("Order History for a customer");
                int count = 0;
                foreach (var order in history)
                {
                    Console.WriteLine($"The order history for {order.Customer}: {count++}. {order.QuanOrder} {order.Product} ordered on {order.DateOrder}");
                }
            }
        }

        //method to recall all order history for a store
        static void StoreOrderHistory()
        {
            //query: select based on store 

            using (var db = new P0DbContext.P0DbContext())
            {
                //select star
                List<P0DbContext.Customer> lister = db.Customers.OrderBy(b => b.Fname).ToList();
                Console.WriteLine("All customers and basic information, ordered by first name.");
                foreach (var cust in lister)
                {
                    //Console.WriteLine($"Name: {cust.Fname} {cust.Lname}  -  Email: {cust.Email}  - {cust. ");
                }
            }
        }

    }
    //class
}//namespace

