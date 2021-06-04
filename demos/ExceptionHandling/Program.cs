using System;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            int five = 5;

            try
            {
                int a = five/0;
            }
            catch (ArithmeticException ex)
            {
                throw new ArithmeticException("This is an example of exception handling", ex);
            }//adding a finally block
            finally{
                Console.WriteLine("The finally block has executed");
            }
            //how to print out the inner exception
            //void LogException(Exception error) {
//     Exception realerror = error;
//     while (realerror.InnerException != null)
//         realerror = realerror.InnerException;

//     Console.WriteLine(realerror.ToString())
// }

//         }
    }
}
