using System;

namespace DelegateSimple
{
    public class MethodsClass
    {
        public void method1(){
            Console.WriteLine($"This is method 1.");
        }
        public void method2(){
            Console.WriteLine($"This is method 2.");
        }
        public void method3(){
            Console.WriteLine($"This is method 3.");
        }
        public int method4(string message){
            Console.WriteLine($"This is method 4.");
            return 1;
        }
        
    }
    class Program
    {
        static void Main(string[]args)
        {
            DelegateClass myDelegateClass = new DelegateClass();
            MethodsClass myMethodsClass = new MethodsClass();

            myDelegateClass.delegateInstance = myMethodsClass.method1;
            myDelegateClass.delegateInstance += myMethodsClass.method2;//needs += so that its added
            myDelegateClass.delegateInstance += myMethodsClass.method3;//otherwise overriden
            myDelegateClass.myNotSimpleDelegate = myMethodsClass.method4;

            //can remove a method from delegate:
            myDelegateClass.delegateInstance -= myMethodsClass.method2;

            myDelegateClass.delegateInstance();
            Console.WriteLine(myDelegateClass.delegateInstance.GetInvocationList().toString());

            //when would you use a delegate?
            //When you have a chain of things that you want concurrently, based on a selection
        }
        }
    }
}