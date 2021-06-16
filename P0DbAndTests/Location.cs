using P0DbContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P0DbAndTests
{
    public class Location : ILocation
    {
        int caseswitch;
        //used for "printing" location menu
        P0DbContext.P0DbContext context = new P0DbContext.P0DbContext();

        //content
        public string City { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string State { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string Address { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string Zip { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }


        public static void StoreView()
        {
            using (var context = new P0DbContext.P0DbContext())
            {

                List<P0DbContext.Location> storelist = context.Locations.Where(l => l.StoreId >= 0).ToList();

                //forreach loop to print out the values (if you just write consolewriteline you get memory address)
                foreach(var store in storelist)
                {
                    Console.WriteLine($"{store.StoreId}. {store.City}, {store.State}");
                }

            }


        }

        //method 3:select stores & output
        public static void SelectStore()
        {
            P0DbContext.P0DbContext context = new P0DbContext.P0DbContext();
            int caseswitch=0;
            System.Console.WriteLine("Please input the number corresponding to the Chubiez location you would like to visit!");
            //output menu of stores aka output two specific columns from the database: storeId and City
            StoreView();

            //take in user input and output different results according to their input, specifically 
            caseswitch = Convert.ToInt32(Console.ReadLine());
            switch (caseswitch)
            {
                case 1:
                    System.Console.WriteLine("Tampa! Great Choice!\n");
                    break;
                case 2:
                    System.Console.WriteLine("NYC! Great Choice!\n");
                    break;
                case 3:
                    System.Console.WriteLine("LA! Great Choice!\n");
                    break;
                case 4:
                    System.Console.WriteLine("Portland! Great Choice!\n");
                    break;
                case 5:
                    System.Console.WriteLine("DC! Great Choice!\n");
                    break;
                case 6:
                    System.Console.WriteLine("Atlanta! Great Choice!\n");
                    break;
            }
            ShowInven(caseswitch);

        }




        //method for each location to have inventory
        public static void ShowInven(int caseswitch)//caseswitch is the variable because it corresponds to the StoreId
        {
            P0DbContext.P0DbContext context = new P0DbContext.P0DbContext();
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

                //query 2. making joined table into list
                //forreach loop to print out the values (if you just write consolewriteline you get memory address)
                foreach (var row in joined.Where(c => c.StoreId == caseswitch))
                {
                    Console.WriteLine($"ProductId.{row.ProductId}   Item:{row.Make}: {row.Text}   Quantity:{row.QuanStore}   Size: {row.Size}   Price:{row.Price}");
                }

                SelectProduct();

            }

        }
        


        //method to select a product from store inventory

        public static void SelectProduct()
        {
            Console.WriteLine("Please select the products you would like to purchase from the store by inputting the ProductId, followed by your desired quantity!");
            int chosenProduct = Convert.ToInt32(Console.ReadLine());
            int chosenQuantity = Convert.ToInt32(Console.ReadLine());
        }
    }//clas
}//namespace