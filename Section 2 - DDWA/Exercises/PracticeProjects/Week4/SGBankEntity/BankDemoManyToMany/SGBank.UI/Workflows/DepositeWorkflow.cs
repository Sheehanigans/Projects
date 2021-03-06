﻿using SGBank.BLL;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflows
{
    public class DepositeWorkflow
    {
        public void Execute()
        {
            Console.Clear();

            AccountManager accountManager = AccountManagerFactory.Create();

            Console.Write("Please enter an account number: ");
            string accountNumber = Console.ReadLine();

            Console.Write("Enter a deposite amount: ");


            decimal amount = decimal.Parse(Console.ReadLine());

            AccountDepositeResponse response = accountManager.Deposite(accountNumber, amount);

            if (response.Success)
            {
                Console.WriteLine("Deposite completed!");
                Console.WriteLine($"Account number: {response.Account.AccountNumber}");
                Console.WriteLine($"Old balance: {response.OldBalance:c}");
                Console.WriteLine($"Amount deposited: {response.Amount:c}");
                Console.WriteLine($"New balance: {response.Account.Balance:c}");
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
