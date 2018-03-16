using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL.DepositeRules
{
    public class FreeAccountDepositeRule : IDeposite
    {
        public AccountDepositeResponse Deposite(Account account, decimal amount)
        {
            AccountDepositeResponse response = new AccountDepositeResponse();

            if (account.Type != AccountType.Free)
            {
                response.Success = false;
                response.Message = "Error: a non free account his the free deposite rule.";
                return response;
            }
            
            if(amount > 100)
            {
                response.Success = false;
                response.Message = "Free accounts cannot deposite more than $100 at a time.";
                return response;
            }

            if(amount <= 0)
            {
                response.Success = false;
                response.Message = "Deposite amounts must be greater than $0";
                return response;
            }

            response.OldBalance = account.Balance;
            account.Balance += amount;
            response.Account = account;
            response.Amount = amount;
            response.Success = true;

            return response;
        }
    }
}
