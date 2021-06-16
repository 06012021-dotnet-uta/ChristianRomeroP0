using P0DbAndTests;
using System;
using Microsoft.EntityFrameworkCore;

using context;
using System.Collections.Generic;
using System.Linq;

namespace P0DbAndTests
{
    public class Order 
    {
        context.P0DbContext context = new context.P0DbContext();
        Cart cart = new Cart();

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
            int counter = 0;
            do
            {
                    Console.WriteLine("Please input the ProductId of your desired item!");
                   int chosenProduct = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please input your desired product quantity!");
                int chosenQuantity = Convert.ToInt32(Console.ReadLine());
                    foreach (var row in joined.Where(c => c.ProductId == chosenProduct))
                    {
                        if (row.QuanStore <= chosenQuantity)
                        {
                            Console.WriteLine("You have selected a quantity that is too large for this store's inventory. Please select a different quantity.");
                            SelectProduct();
                        }
                        else
                        {
                            //if quantity is fine, add to the cart
                            //context.Order order = (context.Order)context.Orders.Where(c => c.ProductId == chosenProduct);//needed explicit cast
                            /*attempt at exception handling. No idea why it's not catching the System.FormatException
                                try
                                {
                                Console.WriteLine("Please input your customerId and the storeId to verify your selected item and quantity.");
                                int input1 = Convert.ToInt32(Console.ReadLine());
                                int input2 = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (System.FormatException e)
                            {

                                throw new System.FormatException("System.FormatException.", e);
                            }
                            finally
                            {
                                    Console.WriteLine("System.FormatException was thrown and caught." );
                            }
                            */
                            //I understand this isn ot feasible business, but displaying a newly made context entity to the user is beyond my scope
                            Console.WriteLine("Please input your customerId and the StoreId.");
                            int customId = Convert.ToInt32(Console.ReadLine());
                            int storeId = Convert.ToInt32(Console.ReadLine());
                            Cart.AddOrder(storeId, chosenProduct, chosenQuantity, customId);
                            Cart.OrderReview(storeId, chosenProduct, chosenQuantity, customId);
                            Console.WriteLine("Would you like to continue shopping? Please input CONTINUE or CHECKOUT.");
                            string conCheck = Console.ReadLine();
                            if (conCheck == "CONTINUE")
                            {
                                counter ++;
                                CreateCart();
                            }
                            if (conCheck == "CHECKOUT")
                            {
                                counter = 0;
                                return;
                                //Console.WriteLine($"Counter is {counter}");
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid commmand.\n");
                            }
                            //method to checkout & get receipts
                            Cart.OrderReview( storeId,  chosenProduct,  chosenQuantity,  customId);
                        }
                    }
            } while (counter !=0);

        }
    }

    public static void SelectProduct()
        {
            Console.WriteLine("Please select the products you would like to purchase from the store by inputting the ProductId, followed by your desired quantity!");
            int chosenProduct = Convert.ToInt32(Console.ReadLine());
            int chosenQuantity = Convert.ToInt32(Console.ReadLine());
        }

    }//class
}//namespace