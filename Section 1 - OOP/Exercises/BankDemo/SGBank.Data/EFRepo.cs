using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public class EFRepo : IAccountRepository
    {
        public Account LoadAccount(string AccountNumber)
        {
            using (var context = new SGBankEntities())
            {
                return context.Accounts.SingleOrDefault(
                    a => a.AccountNumber == AccountNumber);
            }
        }

        public void SaveAccount(Account account)
        {
            using (var context = new SGBankEntities())
            {
                context.Accounts.Attach(account);

                context.Entry(account).State = EntityState.Modified;

                context.SaveChanges();
            }
        }
    }
}
