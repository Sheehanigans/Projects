using SGBank.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models.Responses;

namespace SGBank.UI.Workflows
{
    public class CustomerLookupWorkflow
    {
        public void Execute()
        {
            CustomerManager manager = CustomerManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Lookup an account");
            Console.WriteLine("------------------------");

            int customerId = ConsoleIO.GetCustomerID();

            CustomerLookupResponse response = manager.LookupCustomer(customerId);

            if (response.Success)
            {
                ConsoleIO.DisplayCustomrDetails(response.Customer);
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
