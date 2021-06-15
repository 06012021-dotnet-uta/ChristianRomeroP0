using P0DbContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P0DbAndTests
{
    public class Location : ILocation
    {
        //used for "printing" location menu
        P0DbContext.P0DbContext context = new P0DbContext.P0DbContext();

        //content
        public string City { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string State { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string Address { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string Zip { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public static void SelectStore()
        {
            P0DbContext.P0DbContext context = new P0DbContext.P0DbContext();
            int caseswitch;
            System.Console.WriteLine("Please input the number corresponding to the store you would like to visit!");
            //output menu of stores aka output two specific columns from the database: storeId and City
            using (context)
            {
                var menu = context.Inventories
                               .Where(p => p != null) //select row
                                .Select(p => new { p.StoreId, p.Store });//select column
                /*side note - AHA! moment:
                 * It seems in every .LINQ query that uses lambda expressions we can filter based on row and then column. Makes sense based on SQL 
                */
                Console.WriteLine(menu);
            }

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


        //method for each location to have inventory
        /*public static void ShowInven()
        {
            P0DbContext.P0DbContext context = new P0DbContext.P0DbContext();
            
            using (context)
            {
                //grab the "Inventories table
                var inventory = context.Inventories
                                   .Where(p => p. == "<sql-server>")
                                   .Select(p => p);
            }
        }
        */

    }//clas
}//namespace