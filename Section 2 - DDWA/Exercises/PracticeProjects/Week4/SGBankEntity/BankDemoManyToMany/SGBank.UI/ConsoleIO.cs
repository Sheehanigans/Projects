using SGBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI
{
    public class ConsoleIO
    {
        public static void DisplayAccountDetails(Account account)
        {
            Console.WriteLine($"Account number: {account.AccountNumber}");
            Console.WriteLine($"Balance: {account.Balance:c}");
        }

        internal static int GetCustomerID()
        {
            bool validInput = false;
            int id = 0;

            while (!validInput)
            {
                Console.WriteLine("Please enter the customer id: ");

                string tempId = Console.ReadLine();

                if (string.IsNullOrEmpty(tempId))
                {
                    Console.WriteLine("Blank input.");
                }
                else
                {
                    if (!int.TryParse(tempId, out id))
                    {
                        Console.WriteLine("Invalid choice: not a number.");
                    }
                    else if (id < 0)
                    {
                        Console.WriteLine("Invalid choice: cannot be negative");

                    }
                    else
                    {
                        validInput = true;
                    }
                }
            }
            return id;
        }

        internal static void DisplayCustomrDetails(Customer customer)
        {
            Console.WriteLine($"Customer name: {customer.Name}");
            foreach (var account in customer.Accounts)
            {
                Console.WriteLine($"{account}");
            }
        }
    }
}
