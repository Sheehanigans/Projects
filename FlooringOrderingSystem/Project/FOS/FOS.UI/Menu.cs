using FOS.UI.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.UI
{
    public class Menu
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Weclcome to the SWC Corp Flooring Ordering System");
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("1. Display Orders");
                Console.WriteLine("2. Add an Order");
                Console.WriteLine("3. Edit an Order");
                Console.WriteLine("4. Remove an Order");
                Console.WriteLine("\nQ to Quit");
                Console.WriteLine("\nEnter a selection:");

                string userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "1":
                        DisplayOrdersWorkflow displayWorkflow = new DisplayOrdersWorkflow();
                        displayWorkflow.Execute();
                        break;
                    case "2":
                        //add an order
                        break;
                    case "3":
                        //Edit an order
                        break;
                    case "4":
                        //Remove an order
                        break;
                    case "Q":
                        return;
                }
            }
        }
    }
}
