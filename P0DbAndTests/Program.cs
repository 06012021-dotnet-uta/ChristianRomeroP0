using System;
using P0DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

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

            //Opening console UI & welcoming user
            // Messages.WelcomeScreen();
            Messages.Login();
            //Customer selects store
            Messages.StoreSelect();
            //method to "enter" a store (view store inventory) after user selects a location
            Location.SelectStore();

            //Add Items to cart

            //its simple to query the context

            //inject an instance of the context into every class so thus useable for everyt method
            static void SearchCustomers()
            {
                using (var db = new P0DbContext.P0DbContext()) 
                {
                    //select star
                    var query = db.Customers.OrderBy(b => b.Fname);
                    Console.WriteLine("All customers in DB");
                    Console.WriteLine(query);
                }
            }

            //here is organization
            SearchCustomers();
        }
    }//class
}//namespace
