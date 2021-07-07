using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyQCCoding
{
    class Strings //This class contains notes on Strings in C#
    {
        char[] carrary = {"a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z"};

        string str1;
        string str2 = "this is string 2";
        string str3;
        string str4;
        

        public string stringy { get; set; }


        //String constructors are...constructors for the string class and intake many parameters:

        public void CreateString()
        {
            Console.WriteLine("This string was created using a pointer to an array of Unicode characters");
            this.str1 = String();
            Console.WriteLine("This string was created using characters in an array");
            
            Console.WriteLine("This constructor creates a string that repeats a character N times");
            this.str3 = String("apple",3);
            Console.WriteLine("This constructor creates a string that 'splices' part of an array of unicode characters");
            this.str4 = String(carrary,5,10);
          
        }


        //String properties 

        public void StringProps()
        {
            int i;
            Console.WriteLine("This is the string.length property. Add some blank spaces");
            this.stringy = Console.ReadLine();
            Console.WriteLine(this.stringy.Length);

            for(i=0; i <this.stringy.Length; i++)
            {
                Console.WriteLine($"the {i} character in stringy is:", stringy[i]);
            }
        }

        //String "helper methods"
        public void StringHelpers()
        {
            Console.WriteLine("This is the trim helper method.");
            Console.WriteLine(this.stringy.Trim());

            Console.WriteLine("This method compares 2 strings");
            Compare(str1,str2);

            Console.WriteLine("This is the CompareOrdinal method. By default it compares the numeric values of char objects in the string");
            CompareOrdinal(str1,str2);

            Console.WriteLine("This is an overloaded version:");
            CompareOrdinal(str3,2,str4,2,1);

            Console.WriteLine("The Concat() method is useful for string concatenation of multiple string objects and string array");

            Console.WriteLine("Contains() is useful for determining whether");

            Console.WriteLine("EndsWith() determines whether a string ends with a specified character, string");

            //Equals is useful, as an overloaded method

            Console.WriteLine("IndexOf() is useful for determining whether a String/Char occurs by starting at Int and checking Int spaces");
            Console.WriteLine("LastIndexOf() is the same but gives the index of the final character");
            Console.WriteLine("Don't forget ToLower and ToUpper");
        }
    }
}
