using System;
using context;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace P0BusLogc
{
	public class BusinessLogic
	{
        P0DbContext context = new P0DbContext();
        
        //Function: Acount registration

        //method 1

        //method 2: view stores
        public static void StoreView()
        {
            using (var context = new context.P0DbContext())
            {

                List<context.Location> storelist = context.Locations.Where(l => l.StoreId >= 0).ToList();
                Console.WriteLine(storelist);
            }


        }

        //method 3:select stores & output
        public static void SelectStore()
        {
            context.P0DbContext context = new context.P0DbContext();
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

		//method to make a new acccount
		public void Registration()
        {

        }

        //shopping logic:

        //0)Login/Register & Welcome


        //1) method for a customer to start shopping

        public static void StartShopping()
        {
            P0DbAndTests.Customer cust = new P0DbAndTests.Customer();
            P0DbAndTests.Order ord = new P0DbAndTests.Order();
            P0DbAndTests.Cart cart = new P0DbAndTests.Cart();

            Console.WriteLine("Please input START when you would like to start shopping, or LOGOUT if you would like to logout");
            string start = Console.ReadLine();
            //if START
            if (start == "START"|| start.ToLower() == "start")
            {
                int prod;
                //StoreSelect method 
                SelectStore();//(incorporates StoreView and StoreInven methods)

                //method to create a cart
                CreateCart();
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
            context.P0DbContext context = new context.P0DbContext();
            //join query
            using (context)
            {
                //query: left join context.product & context.inventory BASED ON PRODUCTID and 2nd query return all values where storeId = caseswitch
                //tried using lambda syntax and kept getting an error so I went with query
                //query 1:
                var joined =
                    from p in context.Products
                    join i in context.Inventories on p.ProductId equals i.ProductId
                    select new
                    {
                        ProductId = p.ProductId,
                        Make = p.Make,
                        Text = p.Text,
                        Size = p.Size,
                        Price = p.Price,
                        StoreId = i.StoreId,
                        QuanStore = i.QuanStore,
                    };
                string counter = "continue";
                do
                {
                    Console.WriteLine("Please input the ProductId followed by your desired quantity to add to your shopping cart!");
                    int chosenProduct = Convert.ToInt32(Console.ReadLine());
                    int chosenQuantity = Convert.ToInt32(Console.ReadLine());
                    foreach (var row in joined.Where(c => c.ProductId == chosenProduct))
                    {
                        if (row.QuanStore <= chosenQuantity)
                        {
                            Console.WriteLine("You have selected a quantity that is too large for this store's inventory. Please select a different quantity.");
                        }
                        else
                        {
                            //if quantity is fine, add to the cart
                            context.Order order = (context.Order)context.Orders.Where(c => c.ProductId == chosenProduct);//needed explicit cast
                            Console.WriteLine("Please input your customerId and the storeId to verify your selected item and quantity.");
                            int customId = Convert.ToInt32(Console.ReadLine());
                            int storeId = Convert.ToInt32(Console.ReadLine());
                            //I understand this isn ot feasible business, but displaying a newly made context entity to the user is beyond my scope
                            AddOrder(storeId,chosenProduct,chosenQuantity,customId);
                            Console.WriteLine("Here is your receipt.");
                            OrderReview(storeId, chosenProduct, chosenQuantity, customId);
                        }
                    }
                    Console.WriteLine("Would you like to continue shopping? Please input CONTINUE or CHECKOUT.");
                    string conCheck = Console.ReadLine();
                    if(conCheck == "continue")
                    {
                        counter = "continue";
                    }
                    if(conCheck == "CHECKOUT")
                    {
                        counter = "checkout";
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid commmand.\n");
                        conCheck = Console.ReadLine();
                        if (conCheck == "continue")
                        {
                            counter = "continue";
                        }
                        if (conCheck == "CHECKOUT")
                        {
                            counter = "checkout";
                        }
                    }
                } while (counter != "checkout" );
            }
        }

        public static void SelectProduct()
        {
            Console.WriteLine("Please select the products you would like to purchase from the store by inputting the ProductId, followed by your desired quantity!");
            int chosenProduct = Convert.ToInt32(Console.ReadLine());
            int chosenQuantity = Convert.ToInt32(Console.ReadLine());
        }


        public static void AddOrder(int storeId, int chosenProduct, int chosenQuantity, int customId)
        {
            context.P0DbContext context = new context.P0DbContext();
            using (context)
            {
                var newOrder = new context.Order();
                {
                    newOrder.CustomerId = customId;//comes from customer login
                    newOrder.ProductId = chosenProduct;//comes from var chosen variable
                    newOrder.StoreId = storeId;//comes from caseswitch (reqiures method to be in switch scope)
                    newOrder.QuanOrder = chosenQuantity;
                    newOrder.DateOrder = DateTime.Now;
                };
                context.Orders.Add(newOrder);
                context.SaveChanges();
            }
        }

        public static void OrderReview(int storeId, int chosenProduct, int chosenQuantity, int customId)
        {
            context.P0DbContext context = new context.P0DbContext();
            using (context)
            {
                //create an ordered list of context type Customer via lambda
                List<context.Order> orders = context.Orders.ToList();
                Console.WriteLine("All customers and basic information, ordered by first name.");
                foreach (var cust in orders)//output basic information
                {
                    Console.WriteLine($"Receipt: {cust.QuanOrder} {cust.ProductId} for {cust.Customer} ordered at {cust.DateOrder}.");
                    //in retrospect, after reviewing, this ^ output is better as a "receipt"
                }
            }
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
