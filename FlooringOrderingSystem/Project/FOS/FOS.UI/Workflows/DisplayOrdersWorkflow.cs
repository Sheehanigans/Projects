using FOS.BLL;
using FOS.MODELS.Responses;
using FOS.UI.UI_Elements;
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
            Headers.DisplayOrderHeader();

            //date verification should happen at the order manager or repository level
            DateTime date = ConsoleIO.GetExistingOrderDate("Enter a date to display orders (MM/DD/YYYY):");

            OrderDisplayListResponse response = manager.GetOrderList(date);

            Console.Clear();
            Headers.DisplayOrderHeader();

            if (response.Success)
            {
                foreach(var ord in response.Orders)
                {
                    ShowDetails.DisplayOrderDetails(ord);
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
