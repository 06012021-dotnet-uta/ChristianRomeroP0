namespace P0
{
    public class Messages
    {
//method to prompt welcome screen
        public static void Welcome()
        {
        Console.WriteLine("Welcome to Chubbiz, sister-brand of Chubbies Shorts");
        }

//method to prompt login
        public static void PromptLogin()
        {
            Console.WriteLine("Please input whether you would like to Login or Register");
        }
//incorrect login
        public static void IncorrectLogin()
        {
        Console.WriteLine("The user information does not exist. Please make sure you typed the correct username and password.");
        }

//register or login method
        public static void registerOrLogIn()
        {
            //invokes a previously made method
            PromptLogin();
            string input = Console.ReadLine();
            //If user inputs an invalid registration then prompt again
            if (input != "Register" && input != "Log in")
            {
                Console.WriteLine("Command does not exist");
                registerOrLogIn();
            }
            else
            {
                Console.WriteLine($"Your command was {input}.");
                Console.WriteLine("Username: ");
                string usern = Console.ReadLine();//obtains username
                Console.WriteLine("Password: ");
                string pass = maskPass();//obtains password
                user.setUsername(usern);
                user.setPassword(pass);

                //checks if the username or password exists in the context (database)
                context.Customer.Where( x=> x.Username  == usern && x.pswd == pass);

                //if the login information does not exist in the database output:
                IncorrectLogin();


                if (input == "Register")
                {
                    if (dbVerifyUsername(user.getUsername()))
                    {
                        hashPassword(user.getPassword());
                        dbInsertUser(user.getUsername(), hashPassword(user.getPassword()));
                        Console.WriteLine("You are now registered as {0}", user.getUsername());
                        //dashboard(user.getUsername());
                    }
                    else
                    {
                        Console.WriteLine("Username already exists");
                        registerOrLogIn();
                    }
                }
                if (input == "Log in")
                {
                    SqlConnection connection = new SqlConnection(@"Server=Server;Database=passmanagerdb;Trusted_Connection=true");
                    connection.Open();
                    SqlCommand command = new SqlCommand("Select password from userstbl where username=@usern", connection);
                    command.Parameters.AddWithValue("@usern", user.getUsername());

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string newPass = Convert.ToString(user.getPassword());
                            string oldPass = Convert.ToString(reader["password"]);
                            verifyHashedPass(newPass, oldPass);
                            if (verifyHashedPass(newPass, oldPass))
                            {
                                Console.WriteLine("Grant acces");
                                //dashboard(user.getUsername());
                            }

                            else
                            {
                                Console.WriteLine("Acces denied. Passwords do not match");
                                registerOrLogIn();
                            }

                        }
                        else
                        {
                            Console.WriteLine("Acces denied. Username not found in the database");
                            registerOrLogIn();
                        }
                    }
                    connection.Close();
                }
            }
        }

    }
}