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
            DateTime date = ConsoleIO.GetExistingOrderDate("Enter the date of the order you would like to edit (MM/DD/YYYY): ");

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
            string editName = ConsoleIO.GetCustomerName("edit", orderResponse.Order.CustomerName);

            //edit state
            bool validInput = false;
            StateTax editStateTax = null;
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
                        editStateTax = stateTaxResponse.State;
                        validInput = true;
                    }
                }
            }

            //edit product type
            List<Product> products = productManager.GetProductList().Products;
            Product editProduct = ConsoleIO.DisplayProducts(products, "edit");

            //edit area 

            decimal editArea = ConsoleIO.GetArea("edit");

            //display order changes

            Order editOrder = new Order(orderResponse.Order);

            if(editName != null)
            {
                editOrder.CustomerName = editName;
            }
            if(editStateTax != null)
            {
                editOrder.State = editStateTax.StateName;
                editOrder.TaxRate = editStateTax.TaxRate;
            }
            if(editProduct != null)
            {
                editOrder.ProductType = editProduct.ProductType;
                editOrder.LaborCostPerSquareFoot = editProduct.LaborCostPerSquareFoot;
                editOrder.CostPerSquareFoot = editProduct.CostPerSquareFoot;
            }
            if(editArea != int.MaxValue)
            {
                editOrder.Area = editArea;
            }

            ShowDetails.DisplayOrderDetails(editOrder);

            if(ConsoleIO.GetYesOrNo("Edit this order?") == "Y")
            {
                OrderAddEditedResponse response = orderManager.AddEditedOrderToRepository(editOrder);
                if (!response.Success)
                {
                    Console.WriteLine("There was an error adding the edited order");
                    Console.WriteLine(response.Message);
                }
                else
                {
                    Console.WriteLine("Order added! Press any key to continue...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Edit order cancelled :( Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
