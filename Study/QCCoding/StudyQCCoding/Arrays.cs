using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyQCCoding
{
    //creating arrays are simple:   type[] arrayname = new type[size];
    
    string[] stringarray = new string[10];
    string[] stringarray2 = {"apple","pie","is","very","tasty"};

    int[] intarray= new int[6];
    interface[] intarray2 = new int {1,2,3,4,5,6,7};


    class ArrayFacts
    {
        /*Arrays draw from the base class 'Array' which draws from 4 interfaces:
        1) ICloneable
        2) System.Collections.IList 
        3) System.Collections.IStructuralComparable
        4) System.Collections.IStructuralEquatable
         */

    }


    class ArrayProps
    {
        //Any array has 7 properties:

        Console.WriteLine("IsFixedSize outputs a value stating whether or not an array has a fixed size");
        Console.WriteLine("IsReadOnly outputs a value stating whether or not an array is readonly ");
        Console.WriteLine("IsSynchronized outputs a value stating whether or not an array is thread safe");
        Console.WriteLine("Length outputs a value that is the total number of elements in an array");
        Console.WriteLine("LongLength outputs a value that is the total number of elements in an array, but as a 64 bit integer");
        Console.WriteLine("Rank outputs an integer that states the number of dimensions of an array");
        Console.WriteLine("SyncRoot gets an object that can be used to sync access to the array");


    }

    class ArrayMethods
    {
        //Arrays have TONS of methods. Below is tinkering with some must-know & handy-to-know methods

        Console.WriteLine("Exists<type> (type[]arrayname, ");
        Console.WriteLine("Arrays also use IndexOf and LastIndexOf");
        Console.WriteLine("Sort is useful - default is A-Z");
    }//eoc
}//eon
