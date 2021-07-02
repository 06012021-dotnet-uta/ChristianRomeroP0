using System;

namespace HackerFour
{
   public class Messages
    {
        //method to print out messages that direct user input.
        string consent;


        public static void ObtainConsent()
        {
            System.Console.WriteLine("Would you like play the Staircase game? Y/N");
            //we will need input validation for yes and no
            consent = Console.ReadLine();
            if(consent == "N")
            {
                Console.WriteLine("Ok great. Exit program.");
            }
            if(consent == "Y")
            {
                Console.WriteLine("Ok great. Let's play");
            }
            else
            {
                Console.WriteLine("Please input a valid instruction.");
            }
        }

    }//eoc
}//eon
    