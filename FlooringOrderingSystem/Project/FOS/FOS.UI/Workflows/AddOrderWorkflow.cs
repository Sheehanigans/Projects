using FOS.BLL;
using FOS.BLL.DataVaidations;
using FOS.BLL.DataValidations;
using FOS.MODELS;
using FOS.MODELS.Models;
using FOS.MODELS.Responses;
using FOS.UI.UI_Elements;
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
            string workflow = "add";

            Console.Clear();

            Headers.AddOrderHeader();

            //create order object
            Order newOrder = new Order();

            //get date
            newOrder.Date = ConsoleIO.GetNewOrderDate("Enter a date (MM/DD/YYYY):");

            Console.Clear();
            Headers.AddOrderHeader();

            newOrder.OrderNumber = OrderNumberVaidation.CreateOrderNumber();
            newOrder.CustomerName = ConsoleIO.GetCustomerName("add");

            Console.Clear();
            Headers.AddOrderHeader();

            //get state tax
            bool validState = false;
            StateTax stateTax = null;
            while (!validState)
            {
                string stateAbbratiavtion = ConsoleIO.GetStateInputFromUser("add");
                StateTax tempStateTax = StateTaxValidation.CreateStateTax(stateAbbratiavtion).State;
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

            Console.Clear();
            Headers.AddOrderHeader();

            //set state
            newOrder.State = stateTax.StateAbbreviation;
            newOrder.TaxRate = stateTax.TaxRate;

            //get product
            List<Product> products = ProductListValidation.CreateProductList();
            Product product = ConsoleIO.DisplayProducts(products, "add");
            newOrder.ProductType = product.ProductType;
            newOrder.CostPerSquareFoot = product.CostPerSquareFoot;
            newOrder.LaborCostPerSquareFoot = product.LaborCostPerSquareFoot;

            Console.Clear();
            Headers.AddOrderHeader();

            //get area
            newOrder.Area = ConsoleIO.GetArea("edit");

            Console.Clear();
            Headers.AddOrderHeader();

            //display new order
            ShowDetails.DisplayOrderDetails(newOrder);

            //--show message if add failed--
            if (ConsoleIO.GetYesOrNo("Add order? ") == "Y")
            {
                OrderAddValidation.AddOrder(newOrder);
                Console.WriteLine("Order added! Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Order cancelled :(");
                Console.ReadLine();
            }
        }
    }
}
