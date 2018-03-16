namespace SGBank.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountRefactoring : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CustomerAccounts", new[] { "Customer_id" });
            CreateIndex("dbo.CustomerAccounts", "Customer_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CustomerAccounts", new[] { "Customer_ID" });
            CreateIndex("dbo.CustomerAccounts", "Customer_id");
        }
    }
}
