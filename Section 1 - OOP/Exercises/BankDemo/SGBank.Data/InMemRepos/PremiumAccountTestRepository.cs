﻿using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public class PremiumAccountTestRepository : IAccountRepository
    {
        private static Account _account = new Account()
        {
            Name = "Premium Account",
            Balance = 1000.00M,
            AccountNumber = "55555",
            Type = AccountType.Premium
        };

        public Account LoadAccount(string AccountNumber)
        {
            if (_account.AccountNumber != AccountNumber)
            {
                return null;
            }
            else
            {
                return _account;
            }
        }

        public void SaveAccount(Account account)
        {
            _account = account;
        }
    }
}
