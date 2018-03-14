namespace SGBank.Data.Migrations
{
    using SGBank.Models;
    using System;
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

            context.Accounts.AddOrUpdate(
                a => a.AccountNumber,
                new Account
                {
                    AccountNumber = "66666",
                    Name = "Ryan Sheehan",
                    Balance = 500.00m,
                    Type = AccountType.Premium
                }
                );

            context.SaveChanges();
        }
    }
}
