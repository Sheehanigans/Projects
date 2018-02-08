﻿using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL.DepositeRules
{
    public class DepositeRulesFactory
    {
        public static IDeposite Create(AccountType type)
        {
            switch (type)
            {
                case AccountType.Free:
                    return new FreeAccountDepositeRule();                
            }

            throw new Exception("Account type is not supported");
        }
    }
}