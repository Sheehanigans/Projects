using FOS.BLL;
using FOS.BLL.Factories;
using FOS.BLL.Managers;
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
    public class EditOrderWorkflow
    {
        public void Execute()
        {
            OrderManager orderManager = OrderManagerFactory.Create();
            StateTaxManager stateTaxManager = StateTaxManagerFactory.Create();
            ProductManager productManager = ProductManagerFactory.Create();

            string workflow = "edit";

            Console.Clear();
            Headers.EditOrderHeader();

            //get date
            string date = ConsoleIO.GetExistingOrderDate("Enter the date of the order you would like to edit (MM/DD/YYYY): ");

            Console.Clear();
            Headers.EditOrderHeader();

            int orderNumber = ConsoleIO.GetOrderNumberFromUser("Enter the order number: ");

            OrderDisplaySingleResponse orderResponse = orderManager.DisplaySingleOrder(date, orderNumber);
            if (orderResponse.Success)
            {
                ShowDetails.DisplayOrderDetails(orderResponse.Order);
            }
            else
            {
                Console.WriteLine("An error occured:");
                Console.WriteLine(orderResponse.Message);
                Console.WriteLine("Press any key to return to main menu...");
                Console.ReadKey();
                Menu.Start();
            }

            //edit name
            string editName = ConsoleIO.GetCustomerName("edit");

            //edit state
            bool validInput = false;
            StateTax stateTax = null;
            while (!validInput)
            {
                string editState = ConsoleIO.GetStateInputFromUser("edit");
                if (editState == "")
                {
                    validInput = true;
                }
                else
                {
                    StateTaxResponse stateTaxResponse = stateTaxManager.GetStateTax(editState);
                    if (stateTaxResponse.Success == true)
                    {
                        stateTax = stateTaxResponse.State;
                        validInput = true;
                    }
                }
            }

            //edit product type
            List<Product> products = productManager.GetProductList().Products;
            Product product = ConsoleIO.DisplayProducts(products, "edit");

            Console.WriteLine(product.ProductType);
            Console.ReadLine();

            //edit area 
        }
    }
}
