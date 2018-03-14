using SGBank.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    class SGBankEntities : DbContext
    {
        public SGBankEntities() : base("SGBank")
        {
        }

        public DbSet<Account> Accounts { get; set; }
    }
}
