using NUnit.Framework;
using SGBank.BLL.DepositeRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
    [TestFixture]
    public class PremiumAccountTests
    {
        [TestCase("33333", "Basic Account", 100, AccountType.Free, 250, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Premium, -100, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Premium, 250, true)]

        public void PremiumAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposite deposite = new NoLimitDepositRule();

            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountDepositeResponse response = deposite.Deposite(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }

        [TestCase("33333", "Premium Account", 1500, AccountType.Premium, -1000, 500, true)]
        [TestCase("33333", "Premium Account", 100, AccountType.Free, -100, 100, false)]
        [TestCase("33333", "Premium Account", 100, AccountType.Premium, 100, 100, false)]
        [TestCase("33333", "Premium Account", 150, AccountType.Premium, -50, 100, true)]
        [TestCase("33333", "Premium Account", 100, AccountType.Premium, -150, -60, true)]
        public void PremiumAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdraw withdraw = new PremiumAccountWithdrawRule();

            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Balance = balance;
            account.Name = name;
            account.Type = accountType;

            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }
    }
}
