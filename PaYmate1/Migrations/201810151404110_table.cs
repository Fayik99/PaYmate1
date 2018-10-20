namespace PaYmate1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "BankType", c => c.String());
            DropColumn("dbo.Customer", "CardType");
            DropColumn("dbo.Customer", "CardNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "CardNumber", c => c.String());
            AddColumn("dbo.Customer", "CardType", c => c.String());
            DropColumn("dbo.Customer", "BankType");
        }
    }
}
