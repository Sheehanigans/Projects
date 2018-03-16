namespace SGBank.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Account_AccountNumber = c.String(maxLength: 128),
                        Account_AccountNumber1 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Accounts", t => t.Account_AccountNumber)
                .ForeignKey("dbo.Accounts", t => t.Account_AccountNumber1)
                .Index(t => t.Account_AccountNumber)
                .Index(t => t.Account_AccountNumber1);
            
            AddColumn("dbo.Accounts", "Customer_id", c => c.Int());
            AddColumn("dbo.Accounts", "Customer_id1", c => c.Int());
            CreateIndex("dbo.Accounts", "Customer_id");
            CreateIndex("dbo.Accounts", "Customer_id1");
            AddForeignKey("dbo.Accounts", "Customer_id", "dbo.Customers", "id");
            AddForeignKey("dbo.Accounts", "Customer_id1", "dbo.Customers", "id");
            DropColumn("dbo.Accounts", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "Name", c => c.String());
            DropForeignKey("dbo.Customers", "Account_AccountNumber1", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "Customer_id1", "dbo.Customers");
            DropForeignKey("dbo.Accounts", "Customer_id", "dbo.Customers");
            DropForeignKey("dbo.Customers", "Account_AccountNumber", "dbo.Accounts");
            DropIndex("dbo.Customers", new[] { "Account_AccountNumber1" });
            DropIndex("dbo.Customers", new[] { "Account_AccountNumber" });
            DropIndex("dbo.Accounts", new[] { "Customer_id1" });
            DropIndex("dbo.Accounts", new[] { "Customer_id" });
            DropColumn("dbo.Accounts", "Customer_id1");
            DropColumn("dbo.Accounts", "Customer_id");
            DropTable("dbo.Customers");
        }
    }
}
