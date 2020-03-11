using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace PasswordCreation
{
    public class AccountManager
    {
        Dictionary<string, object> accounts = new Dictionary<string, object>();
        private  string Password { get; set; }
        public  void NewAccount(string username, object password)
        {
            try
            {
                accounts.Add(username, password);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The username you entered already exist. try again.");
                Console.ReadKey();
                Run();
            }
        }

        public  void Run()
        {
            using SHA256 sha256 = SHA256.Create();
            string username, password;

            Console.WriteLine("Please enter a username: ");
            username = Console.ReadLine();
            Console.Clear();
            password = Password;
            do
            {
                if (password != Password)
                {
                    Console.Clear();
                    Console.WriteLine("Passwords did not match. Please try again.");
                }
                Console.WriteLine("Please create a password for your account: ");
                password = Console.ReadLine();
                Console.WriteLine("Please confirm the password for your account: ");
                Password = Console.ReadLine();
            } while (password != Password);

            
            NewAccount(username, Password);
            Console.Clear();
            Console.WriteLine("New Account created");

        }

        public void AccessAccount()
        {
            string username, password;

            Console.WriteLine("Username: ");
            username = Console.ReadLine();
            Console.WriteLine("Password: ");
            password = Console.ReadLine();
            DisplayAccount(username, password);
        }

        public void DisplayAccount(string username, string password)
        {
            if (accounts.ContainsKey(username) == true && accounts.ContainsValue(password) == true)
            {
                Console.WriteLine("Welcome to Skyrim traveler.");
            }
            else
            {
                Console.WriteLine("That combination does not exist in our system.");
            }
        }

        public void DisplayAllAccounts()
        {
            Console.WriteLine("Accounts being deleted: ");
            foreach (var i in accounts)
            {
                Console.WriteLine(i);
            }
        }
    }
}
