using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace PasswordCreation
{
    public class AccountManager
    {
        Dictionary<string, string> accounts = new Dictionary<string, string>();
        
        
        public  void NewAccount(string username, string password)
        {
            try
            {
                accounts.Add(username, password);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The username you entered already exist. try again.");
                Console.ReadKey();
                CreateAccount();
            }
        }

        public  void CreateAccount()
        {
            using SHA256 sha256 = SHA256.Create();
            string username, password1, password2;

            Console.WriteLine("Please enter a username: ");
            username = Console.ReadLine();
            Console.Clear();
            password2 = "";
            password1 = password2;
            do
            {
                if (password1 != password2)
                {
                    Console.Clear();
                    Console.WriteLine("Passwords did not match. Please try again.");
                }
                Console.WriteLine("Please create a password for your account: ");
                password1 = Console.ReadLine();
                Console.WriteLine("Please confirm the password for your account: ");
                password2 = Console.ReadLine();
            } while (password1 != password2);
            password2 = EncryptPW(password1);
            NewAccount(username, password2);
            Console.Clear();
            Console.WriteLine(password2);
            Console.WriteLine("New Account created");

        }

        public string EncryptPW(string password)
        {
            byte[] byts = Encoding.ASCII.GetBytes(password);
            string gibberish = Convert.ToBase64String(byts);
            return gibberish;
        }

        public void AccessAccount()
        {
            string username, password;

            Console.WriteLine("Username: ");
            username = Console.ReadLine();
            Console.WriteLine("Password: ");
            password = Console.ReadLine();
            password = EncryptPW(password);
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
