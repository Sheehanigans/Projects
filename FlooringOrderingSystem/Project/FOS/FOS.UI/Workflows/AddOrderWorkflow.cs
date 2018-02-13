using FOS.BLL;
using FOS.BLL.DataVaidations;
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

            newOrder.OrderNumber = OrderNumberVaidation.CreateOrderNumber();
            newOrder.CustomerName = ConsoleIO.GetCustomerName();

            //get state tax
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

            //set state
            newOrder.State = stateTax.StateAbbreviation;
            newOrder.TaxRate = stateTax.TaxRate;

            //get product
            List<Product> products = ProductListValidation.CreateProductList();
            Product product = ConsoleIO.DisplayProducts(products);
            newOrder.ProductType = product.ProductType;
            newOrder.CostPerSquareFoot = product.CostPerSquareFoot;
            newOrder.LaborCostPerSquareFoot = product.LaborCostPerSquareFoot;

            //get area
            newOrder.Area = ConsoleIO.GetArea();

            //display new order
            ConsoleIO.DisplayOrderDetails(newOrder);

            if (ConsoleIO.GetYesOrNo("Add order? ") == "Y")
            {
                //add it
            }
            else
            {
                Console.WriteLine("Order cancelled");
                Console.ReadLine();
            }

        }
    }
}
