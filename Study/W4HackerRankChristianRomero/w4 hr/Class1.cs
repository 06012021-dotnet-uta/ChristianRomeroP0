using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w4_hr
{
    public class Stair
    {
        /*Program logic:
        1 - Take in a user integer input of N
        2 - Create a method that takes in N
        3 - method execution prints out N number of #'s for N number of lines
        4 - allow user option to "play again" or quit.
        */

        //give Stair a property number which will define the Length and Height

        public int number;


        public int GetInput()//string "answer" will be input that tells the program to execute staircase printing or to exit 
        {
            Console.WriteLine("Please input an integer value according to the number of stairs you'd like!");
            number = Int32.Parse(Console.ReadLine()); //this line makes it so whenever I instantiate a stair class, it will have a number property
            return number;
        }


        public void PrintStaircase(int number)
        {
            Console.WriteLine("Here's your staircase!");
            int i;
            //ffor loop for N
            for (i = 1; i < number+1; i++)
            {
                //print out N #'s

                //Console.WriteLine($"#*{i}");let's see how this goes

                /*first attempt didn't work - did some research on string constructor and came up with this:
                Essentially, the new string constructor creates a string of a certain character iterated upon the scoped variable i. Admittedly, this code
                doesn't align to rightside.

                Perhaps this can be solved:
                1) creating a collection
                2) forloop that CREATES  "N" strings of # of "i" length (up to N+1) and INSERTS the objects into the collection
                3) another loop that iterates across the entire collection (using counter variable "p") to print out each object IN A SPECIFIC FORMAT 
                (right align by "p" cahracters) using: 
                Console.WriteLine([string object], {(index),(alignment)});
                 */
                System.Console.WriteLine(new string('#', i)); // this will print out i number of #'s per line
            }
        }




    }//eoc
}//eon
