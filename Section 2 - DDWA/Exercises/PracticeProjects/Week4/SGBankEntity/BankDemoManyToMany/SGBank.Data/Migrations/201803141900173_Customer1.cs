namespace SGBank.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customer1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Account_AccountNumber", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "Customer_id", "dbo.Customers");
            DropForeignKey("dbo.Accounts", "Customer_id1", "dbo.Customers");
            DropForeignKey("dbo.Customers", "Account_AccountNumber1", "dbo.Accounts");
            DropIndex("dbo.Accounts", new[] { "Customer_id" });
            DropIndex("dbo.Accounts", new[] { "Customer_id1" });
            DropIndex("dbo.Customers", new[] { "Account_AccountNumber" });
            DropIndex("dbo.Customers", new[] { "Account_AccountNumber1" });
            CreateTable(
                "dbo.CustomerAccounts",
                c => new
                    {
                        Customer_id = c.Int(nullable: false),
                        Account_AccountNumber = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Customer_id, t.Account_AccountNumber })
                .ForeignKey("dbo.Customers", t => t.Customer_id, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.Account_AccountNumber, cascadeDelete: true)
                .Index(t => t.Customer_id)
                .Index(t => t.Account_AccountNumber);
            
            DropColumn("dbo.Accounts", "Customer_id");
            DropColumn("dbo.Accounts", "Customer_id1");
            DropColumn("dbo.Customers", "Account_AccountNumber");
            DropColumn("dbo.Customers", "Account_AccountNumber1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Account_AccountNumber1", c => c.String(maxLength: 128));
            AddColumn("dbo.Customers", "Account_AccountNumber", c => c.String(maxLength: 128));
            AddColumn("dbo.Accounts", "Customer_id1", c => c.Int());
            AddColumn("dbo.Accounts", "Customer_id", c => c.Int());
            DropForeignKey("dbo.CustomerAccounts", "Account_AccountNumber", "dbo.Accounts");
            DropForeignKey("dbo.CustomerAccounts", "Customer_id", "dbo.Customers");
            DropIndex("dbo.CustomerAccounts", new[] { "Account_AccountNumber" });
            DropIndex("dbo.CustomerAccounts", new[] { "Customer_id" });
            DropTable("dbo.CustomerAccounts");
            CreateIndex("dbo.Customers", "Account_AccountNumber1");
            CreateIndex("dbo.Customers", "Account_AccountNumber");
            CreateIndex("dbo.Accounts", "Customer_id1");
            CreateIndex("dbo.Accounts", "Customer_id");
            AddForeignKey("dbo.Customers", "Account_AccountNumber1", "dbo.Accounts", "AccountNumber");
            AddForeignKey("dbo.Accounts", "Customer_id1", "dbo.Customers", "id");
            AddForeignKey("dbo.Accounts", "Customer_id", "dbo.Customers", "id");
            AddForeignKey("dbo.Customers", "Account_AccountNumber", "dbo.Accounts", "AccountNumber");
        }
    }
}
