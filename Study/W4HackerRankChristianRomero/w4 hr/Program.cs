using System;

namespace w4_hr
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a staircase of size N
            /*Reqs:
             * 1 - takes in a parameter of integer N [0,100]
             * 2 - prints a staircase of # symbol
             * 3- 
            */

            Stair stair = new Stair();

            stair.GetInput();

            stair.PrintStaircase(stair.number);

        }
    }//eoc
}
