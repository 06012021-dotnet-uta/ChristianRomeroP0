namespace CamelCase
{
    //Single class to count words based on CamelCase logic
    //Check all methods for a given class by: GetMethods()

    public class WordCount
    {
        string welcome = "Hello! Please enter a string consisting of multiple English words in CamelCase.";
        string s;

        public static int Counter()
        {
            int count;
            int length;
            string s = Console.ReadLine();
            /*logic: 
            1) loop over each letter in s
            2) check if letter is uppercase
            3) if uppercase, countervar++
            4) if lowercase, countervar doesn't change
            5) loop until reach the end of a string.
            */

            //assigns a length variables
            length = s.Length;
            
            for(i = 0; i <s.length, i++)
            {
                boolean lc = false;
                //check uppercase s[count]
                //store result in boolean
                if (lc == false){i++}
                else{i=i}
            }

            
        }
    }
    
}