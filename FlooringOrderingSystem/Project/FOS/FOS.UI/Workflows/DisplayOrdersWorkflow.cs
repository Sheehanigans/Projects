using FOS.BLL;
using FOS.MODELS.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.UI.Workflows
{
    public class DisplayOrdersWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Display orders");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Enter a date to display orders (Format: MMDDYYYY):");
            string date = Console.ReadLine();

            OrderDisplayResponse response = manager.DisplayOrders(date);

            if (response.Success)
            {
                foreach(var ord in response.Orders)
                {
                    ConsoleIO.DisplayOrderDetails(ord);
                }
            }
            else
            {
                Console.WriteLine("An error occured: ");
                Console.WriteLine(response.Message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
