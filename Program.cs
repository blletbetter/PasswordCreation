using System;
using System.Security.Cryptography;

namespace PasswordCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            int input;
            AccountManager account = new AccountManager();
            do
            {
                Console.Clear();
                MainMenu();
                var val = Console.ReadLine();
                while (ValidOption(val, out input) == false)
                {
                    MainMenu();
                    val = Console.ReadLine();
                }
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        account.CreateAccount();
                        Console.WriteLine("Press any key to continue...");
                        Console.Read();
                        break;
                    case 2:
                        Console.Clear();
                        account.AccessAccount();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        account.DisplayAllAccounts();
                        return;
                    default:
                        Console.WriteLine("\n\nInvalid option, please try again.");
                        Console.Clear();
                        break;

                }
            } while (input != 3);

        }

        public static void MainMenu()
        {
            Console.WriteLine("Welcome to Account Creation Manager! What would you like to do?");
            Console.WriteLine("Options:\n1.) Create New Account\n2.) Login to account\n3.) Exit application");
            Console.WriteLine("Your choice: ");
        }
        static bool ValidOption(string input, out int option)
        {
            return Int32.TryParse(input, out option);
        }
    }
}
