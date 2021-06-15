using System;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace PasswordManagerwithCRUDoperations
{
    class Program
    {
        static void Main(string[] args)
        {
            registerOrLogIn();
        }
        static void registerOrLogIn()
        {
            Console.WriteLine("Write 'Register' if you want to sign up or 'Log in' if you want to sign in");
            string input = Console.ReadLine();
            if (input != "Register" && input != "Log in")
            {
                Console.WriteLine("Command does not exist");
                registerOrLogIn();
            }
            else
            {
                Console.WriteLine("Your command was {0}", input);
                Credentials user = new Credentials();
                Console.WriteLine("Username: ");
                string usern = Console.ReadLine();
                Console.WriteLine("Password: ");
                string pass = maskPass();
                user.setUsername(usern);
                user.setPassword(pass);
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

        static string maskPass()
        {
            string pass = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return pass;
        }
        static bool dbVerifyUsername(string usern)
        {
            SqlConnection connection = new SqlConnection(@"Server=Server;Database=passmanagerdb;Trusted_Connection=true");
            connection.Open();
            SqlCommand command = new SqlCommand("Select id from userstbl where username=@usern", connection);
            command.Parameters.AddWithValue("@usern", usern);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    connection.Close();
                    return false;
                }
                else
                {
                    connection.Close();
                    return true;
                }
            }
        }
        static string hashPassword(string pass)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            byte[] salt = new byte[16];
            provider.GetBytes(salt);
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(pass, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string savedPass = Convert.ToBase64String(hashBytes);
            return savedPass;
        }
        static bool verifyHashedPass(string newPw, string oldPw)
        {   //reader["password"] - oldPw
            //user.getPassword() -newPw
            string theSavedPass;
            theSavedPass = Convert.ToString(oldPw);
            byte[] hashBytes = Convert.FromBase64String(theSavedPass);

            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(newPw, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            bool ok = true;
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    ok = false;
                }
            }
            return ok;
        }
        static void dbInsertUser(string usern, string pass)
        {
            SqlConnection connection = new SqlConnection(@"Server=Server;Database=passmanagerdb;Trusted_Connection=true");
            connection.Open();
            SqlCommand command = new SqlCommand("Insert into userstbl (username, password) values (@usern, @pass)", connection);
            command.Parameters.AddWithValue("@usern", usern);
            command.Parameters.AddWithValue("@pass", pass);
            command.ExecuteNonQuery();
            connection.Close();
        }

        class Credentials
        {
            private string username;
            private string password;

            public void setUsername(string usern)
            {
                username = usern;
            }
            public string getUsername()
            {
                return username;
            }
            public void setPassword(string pass)
            {
                password = pass;
            }

            public string getPassword()
            {
                return password;
            }
        }
    }
}