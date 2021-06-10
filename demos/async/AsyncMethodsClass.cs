namespace AsyncDemo

class AsyncMethodsClass
{
        //all the awaiting in the methods adds up to 10s
        //instead of awaiting we should return to task of type equal to method return type


        //Basically, in main method execution put the awaits at the end for concurrent execution.
        
    public async Task<string> Method1()
        {
        System.Console.WriteLine("Method 1 is BT.");
        Task task = Task.Delay(1000);
        System.Console.WriteLine("Method 1 is AT.");
        //method returns string due to Task type
        // System.Console.WriteLine("Please write a sentence");
        // string userInput =Console.ReadLine();
        //await the task so that 
        await task;
        System.Console.WriteLine("Method 1 is AAT.");
        return "This is a string.";//automatically the string turns into a task 
        }

        public async Task<int> Method2()
        {
        System.Console.WriteLine("Method 2 is BT.");
        Task task = Task.Delay(2000);
        System.Console.WriteLine("Method 2 is AT.");
        //method returns string due to Task type
        // System.Console.WriteLine("Please write a sentence");
        //int num; 
        // string userInput =Int32.TryParse(Console.ReadLine());
        await task;
        System.Console.WriteLine("Method 2 is AAT.");
        return 1;//automatically the string turns into a task 
        }
        //the two tasks can be named the same thing w/o interfering each outher because of different scopes

       public async Task<int> Method3()
        {
        System.Console.WriteLine("Method 3 is BT.");
        Task task = Task.Delay(3000);//Task doesn't change what you return. just saying that its something you have to wait for
        System.Console.WriteLine("Method 2 is AT.");
        //method returns string due to Task type
        // System.Console.WriteLine("Please write a sentence");
        //int num; 
        // string userInput =Int32.TryParse(Console.ReadLine());
        await task;
        System.Console.WriteLine("Method 3 is AAT.");
        return 3;//automatically the string turns into a task 
        }

       public async Task<Person> Method4()
        {
        System.Console.WriteLine("Method 4 is BT.");
        Task task = Task.Delay(4000);
        System.Console.WriteLine("Method 4 is AT.");
        Person p  = new Person() {Fname = };
        // string userInput =Int32.TryParse(Console.ReadLine());
        await task;
        System.Console.WriteLine("Method 4 is AAT.");
        return 4;//automatically the string turns into a task 
        }
}
        