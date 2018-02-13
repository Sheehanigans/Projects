using FOS.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.UI
{
    public class ConsoleIO
    {
        public static void DisplayOrderDetails (Order order)
        {
            Console.WriteLine($"**************************************");
            Console.WriteLine($"{order.OrderNumber} | {order.Date}");
            Console.WriteLine($"{order.CustomerName}");
            Console.WriteLine($"{order.State}");
            Console.WriteLine($"Product: {order.ProductType}");
            Console.WriteLine($"Materials: {order.MaterialCost}");
            Console.WriteLine($"Labor: {order.LaberCost}");
            Console.WriteLine($"Tax: {order.Tax}");
            Console.WriteLine($"Total: {order.Total}");
            Console.WriteLine($"**************************************");
        }

        public static string GetDate(string prompt)
        {
            bool isValid = false;
            DateTime date = DateTime.Now;
            while (!isValid)
            {
                Console.WriteLine(prompt);

                string orderDate = Console.ReadLine();

                if (string.IsNullOrEmpty(orderDate))
                {
                    Console.WriteLine("Enter a valid order date!");
                }
                else
                {
                    if (!DateTime.TryParse(orderDate, out date))
                    {
                        Console.WriteLine("Enter a valid order date!");
                    }
                    else if (date < DateTime.Now)
                    {
                        Console.WriteLine($"The date entered must be greater than {DateTime.Now.ToString("MM/dd/yyyy")}");
                    }
                    else
                    {
                        isValid = true;
                    }
                }
            }

            return date.ToString("MMddyyyy");
        }

        public static string GetStateInputFromUser()
        {
            bool isValidState = false;
            string state = "";

            while (!isValidState)
            {
                Console.WriteLine("Please enter a state in the following format: OH, MN, etc.");
                string tempState = Console.ReadLine().ToUpper();
                if (string.IsNullOrEmpty(tempState))
                {
                    Console.WriteLine("State input blank.");
                }
                else if (tempState.Length > 2 || tempState.Length < 2)
                {
                    Console.WriteLine("State input incorrect length.");
                }
                else if (tempState.Any(char.IsNumber))
                {
                    Console.WriteLine("State input cannot contain numbers.");
                }
                else
                {
                    state = tempState;
                    isValidState = true;
                }
            }

            return state;
        }

        public static string GetCustomerName()
        {
            bool validName = false;
            string name = "";

            while (!validName)
            {
                Console.WriteLine("Please enter the customer name:");
                string tempName = Console.ReadLine();

                if (string.IsNullOrEmpty(tempName))
                {
                    Console.WriteLine("Enter a valid order date!");
                }
                else
                {
                    validName = true;
                    return tempName;
                }

            }
            return name;
        }
    }
}
