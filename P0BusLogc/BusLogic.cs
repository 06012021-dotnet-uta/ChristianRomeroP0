using System;
using P0DbContext;
using P0DbAndTests;
using System.Collections.Generic;
using System.Linq;

namespace P0BusLogc
{
	public class BusinessLogic
	{

        //method 1

        //method 2: view stores
        public static void StoreView()
        {
            using (var context = new P0DbContext.P0DbContext())
            {

                List<P0DbContext.Location> storelist = context.Locations.Where(l => l.StoreId >= 0).ToList();
                Console.WriteLine(storelist);
            }


        }

        //method 3:select stores & output
        public static void SelectStore()
        {
            P0DbContext.P0DbContext context = new P0DbContext.P0DbContext();
            int caseswitch;
            System.Console.WriteLine("Please input the number corresponding to the store you would like to visit!");
            //output menu of stores aka output two specific columns from the database: storeId and City
            StoreView();

            //take in user input and output different results according to their input, specifically 
            caseswitch = Convert.ToInt32(Console.ReadLine());
            switch (caseswitch)
            {
                case 1:
                    System.Console.WriteLine("Tampa! Great Choice!");
                    break;
                case 2:
                    System.Console.WriteLine("NYC! Great Choice!");
                    break;
                case 3:
                    System.Console.WriteLine("LA! Great Choice!");
                    break;
                case 4:
                    System.Console.WriteLine("Portland! Great Choice!");
                    break;
                case 5:
                    System.Console.WriteLine("DC! Great Choice!");
                    break;
                case 6:
                    System.Console.WriteLine("Atlanta! Great Choice!");
                    break;
            }

        }

        //instantiate a "context" -an "object" of the database
        //had to specify because it was giving me an compiler error 
        P0DbContext.P0DbContext context = new P0DbContext.P0DbContext();

		//method to make a new acccount
		public void Registration()
        {

        }

        //shopping logic:

        //0)Login/Register & Welcome


        //1) method for a customer to start shopping

        public static void StartShopping()
        {
            Console.WriteLine("Please input START when you would like to start shopping, or LGGOUT if you would like to logout");
            string start = Console.ReadLine();
            //if START
            if (start == "START"|| start.ToLower() == "start")
            {
                int prod;
                //StoreSelect method 
                SelectStore();//(incorporates StoreView and StoreInven methods)

                //method to create a cart

                //collect user input on productID as int
                Console.WriteLine("Select a product you would like to add to your cart by inputting the ProductId");
                prod = Convert.ToInt32(Console.ReadLine());
                //logic to add product to array/collection
                Console.WriteLine("Add to shopping cart! Select another product or checkout by inputting checkout!");


            }
            //if not START
            if (start == "LOGOUT"|| start.ToLower() == "logout")
            {
                Console.WriteLine("You have successfully logged out.");
            }
            if (start == "QUIT"|| start.ToLower()=="quit")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Input not recognized.Please input START when you would like to start shopping, or LGGOUT if you would like to logout");
            }
        }


        //nested method to add to cart when user inputs "add to cart"
        public static void CreateCart()
        {

        }

        public static void AddCart()
        {

        }
        //collect user input on productID as int
        //prompt user for quantity
        //prompt user to checkout or keep shopping
        //continue until user inputs to console "checkout"
        //all items are bundled and added to an Order w/ the same OrderId
        //method to display cart details (output the Order query as a list)
        //nested method to get price total
        //method for user to confirm purchase
        //if time, let them adjust cart - otherwise they will pay
        //prompt user with options:
        //shop at current location again
        //shop at different location
        //logout
        //method preventing application from closing unless "quit" is input

    }//class
}//namepsace
