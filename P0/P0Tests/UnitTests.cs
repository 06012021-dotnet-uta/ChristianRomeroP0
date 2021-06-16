using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace P0Tests
{
    public class UnitTests
    {


        public class UnitTest1
        {
            [Fact]
            public void RegisterTest()
            {
                //create a test that would throw an exeption via this method
            }
        }

        public class UnitTest2
        {
            [Fact]
            public void StoreMenuTest()
            {
                //input test that would throw & solve exception from not inputting a string
            }
        }

        public class UnitTest3
        {
            [Fact]
            public void OrderReviewTest()
            {
                //Arrange

                context.P0DbContext context = new context.P0DbContext();
                context.Order unitTest = new context.Order();//makes new order
                //declare parameters
                int storeId = 5;
                int chosenProduct = 1150;
                int chosenQuantity = 1;
                int customId = 1;
                //add order to Db context
                P0DbAndTests.Cart.AddOrder(storeId, chosenProduct, chosenQuantity, customId);


                //lambda query
                using (context)
                {

                    //create an ordered list of context type Customer via lambda
                    List<context.Order> orders = context.Orders.ToList();
                    foreach (var unit in orders.Where(o => o.StoreId == storeId && o.ProductId == chosenProduct && o.QuanOrder == chosenQuantity
                    && o.CustomerId == customId))
                    {
                        Console.WriteLine($"{unit}");
                    }
                }
                    //Act
                    P0DbAndTests.Cart.OrderReview( storeId,  chosenProduct,  chosenQuantity,  customId);

                //Assert

                //check if expected is same as 
            }
        }
    }
}//namespace
