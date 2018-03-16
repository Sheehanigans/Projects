namespace SGBank.Data.Migrations
{
    using SGBank.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SGBank.Data.SGBankEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SGBank.Data.SGBankEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Accounts.AddOrUpdate(new Account() { AccountNumber = "111", Type = AccountType.Premium });

            context.Customers.AddOrUpdate(m => m.Name,
                new SGBank.Models.Customer()
                {
                    Name = "Ryan"
                }
                );

            context.SaveChanges();

            var ryanCustomer = context.Customers.Include(c => c.Accounts).Single(c => c.Name == "Ryan");

            var firstAccount = context.Accounts.Include(a => a.Customers).Single(a => a.AccountNumber == "111");

            if (!firstAccount.Customers.Contains(ryanCustomer))
            {
                firstAccount.Customers.Add(ryanCustomer);
            }
            if (!ryanCustomer.Accounts.Contains(firstAccount))
            {
                ryanCustomer.Accounts.Add(firstAccount);
            }

            context.SaveChanges();
        }
    }
}
