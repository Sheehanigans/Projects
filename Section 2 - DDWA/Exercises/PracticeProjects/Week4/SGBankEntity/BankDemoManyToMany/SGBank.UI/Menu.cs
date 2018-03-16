using SGBank.UI.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI
{
    public class Menu
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("SG Bank application");
                Console.WriteLine("------------------------------");
                Console.WriteLine("1. Lookup an Account");
                Console.WriteLine("2. Deposite");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Lookup a Customer");
                Console.WriteLine("\nQ to quit");
                Console.WriteLine("\nEnter selection");

                string userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "1":
                        AccountLookupWorkflow lookupWorkflow = new AccountLookupWorkflow();
                        lookupWorkflow.Execute();
                        break;
                    case "2":
                        DepositeWorkflow depositeWorkflow = new DepositeWorkflow();
                        depositeWorkflow.Execute();
                        break;
                    case "3":
                        WithdrawWorkflow withdrawWotkflow = new WithdrawWorkflow();
                        withdrawWotkflow.Execute();
                        break;
                    case "4":
                        CustomerLookupWorkflow customerWorkflow = new CustomerLookupWorkflow();
                        customerWorkflow.Execute();
                        break;
                    case "Q":
                        return;
                }
            }

        }
    }
}
