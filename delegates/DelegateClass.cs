namespace DelegateSimple
{
    public class DelegateClass
    {
        //create a method for the delegate to use
        public static void DelegateMethod(){

        }
        //declare a delegate type to define the return type in the delegate signature
        public delegate void SimpleDelegate();

        //create instance of delegate and assign things to it.
        public SimpleDelegate delegateInstance = new SimpleDelegate();

        public delegate int NotSimpleDelegate(string message);
        public NotSimpleDelegate myNotSimpleDelegate;
    }
}