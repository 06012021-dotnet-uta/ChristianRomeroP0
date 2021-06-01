using System;

namespace first_hello_world
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is the assigned program.");
            Console.ReadLine();//this will read the line I output
            //ctrl+click a method for metadata on that method (ie the overloaded)
            //random gen of selecting rock, paper,scissors for the computer to choose from
            
            //prompt user to input age
            Console.WriteLine("Please enter your name:");
            string userName = Console.ReadLine();
            //prompt user forname
            Console.WriteLine("Please enter your age:");
            // Create a string variable and get user input from the keyboard and store it in the variable
            string userAge = Console.ReadLine();
            //print user name+age with string interpolation
            Console.Write($"{userName}'s age is {userAge}");
        }
    }
}
