using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        private string filePath = @"C:\Repos\ryan-sheehan-individual-work\Exercises\BankDemo\SGBankDemo\Data\Accounts.txt";

        public List<Account> List()
        {
            List<Account> accounts = new List<Account>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Account newAccount = new Account();

                    string[] columns = line.Split(',');

                    newAccount.AccountNumber = columns[0];
                    newAccount.Name = columns[1];
                    newAccount.Balance = decimal.Parse(columns[2]);

                    string acctType = columns[3];

                    switch (acctType)
                    {
                        case "F":
                            newAccount.Type = AccountType.Free;
                            break;
                        case "B":
                            newAccount.Type = AccountType.Basic;
                            break;
                        case "P":
                            newAccount.Type = AccountType.Premium;
                            break;
                        default:
                            throw new Exception("Unable to read account type");
                    }

                    accounts.Add(newAccount);
                }
            }

            return accounts;
        }

        public Account LoadAccount(string AccountNumber)
        {
            var accounts = List();

            Account account = new Account();

            foreach (Account acct in accounts)
            {
                if (acct.AccountNumber == AccountNumber)
                {
                    account = acct;
                }
            }

            return account;
        }

        public void SaveAccount(Account account)
        {
            {
                List<Account> accounts = List();
                foreach (var bankAccount in accounts)
                {
                    if (bankAccount.AccountNumber == account.AccountNumber)
                    {
                        bankAccount.Balance = account.Balance;
                    }
                }
                CreateAccountsFile(accounts);

            }
        }

        private string CreateCsvForAccount(Account account)
        {
            string accountType = "";

            if (account.Type == AccountType.Free)
                accountType = "F";
            else if (account.Type == AccountType.Basic)
                accountType = "B";
            else if (account.Type == AccountType.Premium)
                accountType = "P";

            return string.Format("{0},{1},{2},{3}", account.AccountNumber,
                    account.Name, account.Balance, accountType);
        }

        private void CreateAccountsFile(List<Account> accounts)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            using (StreamWriter sr = new StreamWriter(filePath))
            {
                sr.WriteLine("AccountNumber,Name,Balance,Type");
                foreach(var account in accounts)
                {
                    sr.WriteLine(CreateCsvForAccount(account));
                }
            }
        }
    }
}
