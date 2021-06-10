using System;

namespace AsyncDemo
{
    class Program
    {
//only an async method can call an async method
//must have a Task return type
        static async Task Main(string[] args)
        {
            AsyncMethodsClass amc = new AsyncMethodsClass();

            var task1 = amc.Method1();//if you don't know what the return type is you can put var & let system decide
            Task<string> task1 = amc.Method1();

            //have to put another await because the METHOD is awaiting (see method body)
            //and here the MAIN METHOD is awaiting the other async methods
            string Method1 = await amc.Method1();
            System.Console.WriteLine($"method1 returned {method1}");
            int Method1 = await amc.Method2();
            System.Console.WriteLine($"method2 returned {method2}");
            int Method1 = await amc.Method3();
            System.Console.WriteLine($"method3 returned {method3}");
            Person Method1 = await amc.Method4();
            System.Console.WriteLine($"method4 returned {method4}");


        }
    }
}
