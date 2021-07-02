using System;

namespace HackerFour
{
     class Program
    {
        Stair stair = new Stair();
         static void Main(string[] args)
        {
            //create a staircase of size N
            /*Reqs:
             * 1 - takes in a parameter of integer N [0,100]
             * 2 - prints a staircase of # symbol
             * 3- 
            */



            //Messages.ObtainConsent();

            //Stair.PrintStaircase(number)

            stair.GetInput();
            stair.PrintStaircase(stair.number);
                
        }
    }//eoc
}//eon
