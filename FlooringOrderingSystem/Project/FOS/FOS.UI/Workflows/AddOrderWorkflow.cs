using FOS.BLL;
using FOS.BLL.DataValidations;
using FOS.MODELS;
using FOS.MODELS.Models;
using FOS.MODELS.Responses;
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

            //going to need to use date value to pass through to DisplayOrders for number in Manager instead of CreateOrderNumber... 
            //needs to be the order number within the specific file... ListOrders might still work idk

            newOrder.OrderNumber = OrderNumberVaidation.CreateOrderNumber();
            newOrder.CustomerName = ConsoleIO.GetCustomerName();

            //state tax
            bool validState = false;
            StateTax stateTax = null;
            while (!validState)
            {
                string stateAbbratiavtion = ConsoleIO.GetStateInputFromUser();
                StateTax tempStateTax = StateTaxValidation.CreateStateTax(stateAbbratiavtion);
                if(tempStateTax == null)
                {
                    validState = false;
                }
                else
                {
                    stateTax = tempStateTax;
                    validState = true;
                }
            }
            newOrder.State = stateTax.StateAbbreviation;



            Console.WriteLine(newOrder.CustomerName);
            Console.WriteLine($"{stateTax.StateAbbreviation},{stateTax.StateName},{stateTax.TaxRate}, {newOrder.State}");

            Console.ReadLine();
        }
    }
}
