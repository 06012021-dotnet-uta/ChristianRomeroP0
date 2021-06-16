using System;
using System.Collections.Generic;
using System.Linq;
using context;

namespace P0DbAndTests
{
    public class Messages
    {
        context.P0DbContext context = new context.P0DbContext();
        //properties to be used in methods



        //method to prompt welcome screen
        public static void Welcome()
        {
        Console.WriteLine("Welcome to Chubbiz, sister-brand of Chubbies Shorts");
        }

//method to prompt login
        public static void PromptLogin()
        {
            Console.WriteLine("Please input whether you would like to REGISTER or LOGIN");
        }
//incorrect login
        public static void IncorrectLogin()
        {
        Console.WriteLine("The user information does not exist. Please make sure you typed the correct username and password.");
        }

        /*I was struggling with how to add a new account because I was trying to implement it similarly to the AddOrder mmethod, but 
         * it kept giving me an error.
        I found some help through Winston's code. I wholly credit him for this code and I outlined the understanding I gleaned from
        seeing his code and explaining the understanding gained.
        1) create variables within the scope of the method that will be assigned values according
        to the user input. Creating these within the scope of the method means they will 
        disappear after execution, but that's ok because
        2) a nested method within the Register method will create a new Customer class and 
        commit that new object to the database, upon execution. Once executed, the overall Register
        method ends, thus removing the scope variables and minimizing memory usage.
        */

        //This is also a great opportunity to xUnit test and see the limitations of this approach
        public static void Register()
        {
            string Fname;
            string Lname;
            int Age;
            string Username;
            string Password;
            int Member;
            string Email;
            string Mailing;
            string City;
            string State;
            int Zip;
            int count = 0;
            //gets first name
                Console.WriteLine("Please enter your first name.");
                Fname = Console.ReadLine();
                Console.WriteLine("Please enter your last name.");
                Lname = Console.ReadLine();
                Console.WriteLine("Please enter your age.");
                Age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter your desired username.");
                Username = Console.ReadLine();
                Console.WriteLine("Please enter your desired password.");
                Password = Console.ReadLine();
                Console.WriteLine("Please enter whether you would like to sign up as a Member! 0 for No, 1 for Yes!");
                Member = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter your email.");
                Email = Console.ReadLine();
                Console.WriteLine("Please enter your mailing address.");
                Mailing = Console.ReadLine();
                Console.WriteLine("Please enter your city.");
                City = Console.ReadLine();
                Console.WriteLine("Please enter your state.");
                State = Console.ReadLine();
                Console.WriteLine("Please enter your Zip Code.");
                Zip = Convert.ToInt32(Console.ReadLine());
                count++;
                CommitCustomer(Fname, Lname, Age, Username, Password, Member, Email, Mailing, City, State, Zip);
 
        }

        //method to commit changes
            public static void CommitCustomer(string Fname, string Lname, int Age, string Username, 
                string Password, int Member, string Email, string Mailing, string City, string State, int Zip)
            {
            context.P0DbContext context = new context.P0DbContext();
            using (context)
            {
                var newCustomer = new context.Customer();
                newCustomer.Fname = Fname;
                newCustomer.Lname = Lname;
                newCustomer.Age = Age;
                newCustomer.Username = Username;
                newCustomer.Password = Password;
                newCustomer.Member = Convert.ToBoolean(Member);
                newCustomer.Email = Email;
                newCustomer.Mailing = Mailing;
                newCustomer.City = City;
                newCustomer.State = State;
                newCustomer.Zip = Zip;
            }

            }
            

            //I understand now see how dependency injection helps by allowing classes to have
            //a built in context instead of making each method instantiate the context


        public static void EnteringLogin()
        {
            Console.WriteLine("Please enter username:");
            string usern = Console.ReadLine();
            Console.WriteLine("Please enter password:");
            string pwd = Console.ReadLine();
        }

        public static void Login()
        {
            context.P0DbContext context = new context.P0DbContext();
            Console.WriteLine("Please enter your username:");
            string usern = Console.ReadLine();
            Console.WriteLine("Please enter your password:");
            string pwd = Console.ReadLine();
            //check if username and password exist in db..
            if (context.Customers.Any(u => u.Username == usern) && context.Customers.Any( u => u.Password == pwd))
            {
                //if returns a match, ouptut a welcome screen...
                Console.WriteLine("Login successful");
            }
            else
            {
                // otherwise prompt user to try again.
                Console.WriteLine("Account information not found. Ensure you are inputting correct information and please try again.");
                EnteringLogin();
                Console.WriteLine("Second failed attempt. Would you like to register an account?");
                Register();
            }
        }

        //register or login method
        public static void RegisterOrLogIn()
        {
            //invokes a previously made method
            PromptLogin();
            string input = Console.ReadLine();
            //If user inputs an invalid registration then prompt again
            if (input != "REGISTER" && input != "LOGIN")
            {
                //input validation
               Console.WriteLine("Command does not exist");
               PromptLogin();
            }
            if(input == "REGISTER")
            {
                Register();
                Console.WriteLine("User successfully registered.");
            }
            if (input == "LOGIN")
            {
                Login();
            }
            
            
         }

        public static void WelcomeScreen()
        {
            Welcome();
            RegisterOrLogIn();
        }

        public static void ChooseView()
        {
            Console.WriteLine("Would you like to view customer data? Y/N?");
            string input = Console.ReadLine();
            if(input == "Y")
            {
                Console.WriteLine("Input a customerId to view data.");
                int num= Convert.ToInt32(Console.ReadLine()); ;
                Customer.CustomerOrderHistory(num);
            }
            if(input =="N")
            {
                Program.StartShopping();
            }
        }

    }//class
}//namespace