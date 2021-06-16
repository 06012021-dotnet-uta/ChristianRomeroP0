using System;
using System.Collections.Generic;
using System.Linq;
using P0DbAndTests;
using static context.P0DbContext;

namespace P0DbAndTests
{
    public class Cart
    {
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
                Console.WriteLine("Order Review of a specific order.");
                //specific Order, determined by parameter values matching the context.Order row values
                IEnumerable<context.Order> custs = orders.Where(c => c.StoreId == storeId && c.CustomerId == customId && c.ProductId == chosenProduct);
                foreach (var cust in custs)//output basic information
                {
                    Console.WriteLine($"Receipt: {cust.QuanOrder} {cust.ProductId} for {cust.Customer} ordered at {cust.DateOrder}.");
                    //in retrospect, after reviewing, this ^ output is better as a "receipt"
                }
            }
        }
    }//class
}//namespace