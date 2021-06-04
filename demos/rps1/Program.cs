using System;

namespace rps1
{
    class Program
    {
        public enum RPS
        {
            Rock = 1,
            Paper = 2,
            Scissors =3
        }

        int playerChoiceInt
        static void Main(string[] args)
        {
            //Game start
            Console.WriteLine("This is a simple Bo3 of Rock, Paper, Scissors. Would you like to play? (Y/N)");
            string startChoice = Console.ReadLine();
            if (startChoice == "Y")
            {
                //a loop that incrememnts in each round
                while ()
                {
                    
                }
                //game logic
                Console.WriteLine("Great! Choose:\n Rock\nPaper\nScissors");
                //take inputs
                string input = Console.ReadLine();
                input = Int32.TryParse(input, out playerChoiceInt);
                //if inputs are valid choices
                if(playerChoiceInt >)
                playerChoice = enum.playerChoiceInt
                //if inputs are not valid
                Console.WriteLine("Please input a valid choice.");
            }
            else
            {
                Console.WriteLine("Understandable. Have a nice day!");
            }
            //This is computer RPS selection 


            //random number gen that picks from 1-3
            Random rnd = new Random();
            int roll = rnd.Next(1,4);
            rand.Next(RPSchoice.length)
            Console.WriteLine($"Player chose {playerChoiceInt}");
            Console.WriteLine($"Computer chose {roll}");
            

            //prompt user input of string 
            
            //compare values of the two classes
            //maybe property that one class is larger than another?

            //output "(class) beats (class)"!

            //do 3 rounds & print winner of the Bo3

            //do you want to play again?






            // //Mark's
            // bool successfulConversion = false;
            // int playerChoiceInt;
            // do
            // {
            // Console.WriteLine("Welcome to the game.");
            // string playerChoice = Console.ReadLine();

            // //int var to catch converted choice
            
            // bool successfulConversion = Int32.TryParse(playerChoice,out playerChoiceInt);

            // }while(!successfulConversion && );

            // // if(successfulConversion == true)
            // // {
            // //     Console.WriteLine($"The conversion was successful");
            // // }
            // // else
            // // {
            // //     Console.WriteLine($"The conversion was unsuccessful");
            // // }
        }
    }
}
