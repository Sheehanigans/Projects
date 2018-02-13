using FOS.BLL;
using FOS.BLL.Helpers;
using FOS.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.UI.Workflows
{
    public class AddOrderWorkflow
    {
        public void Execute()
        {
            OrderManager orderManager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Add an order:");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();

            //create order object

            Order newOrder = new Order();

            newOrder.Date = ConsoleIO.GetDate("Please enter a date in the following format: 01/01/2020");
            Console.WriteLine(newOrder.Date);

            //going to need to use date value to pass through to DisplayOrders for number in Manager instead of CreateOrderNumber... 
            //needs to be the order number within the specific file... ListOrders might still work idk

            newOrder.OrderNumber = OrderNumber.CreateOrderNumber();

            Console.WriteLine(newOrder.OrderNumber);
            Console.ReadLine();
        }
    }
}
