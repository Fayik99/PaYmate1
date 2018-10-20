namespace PaYmate1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "PhoneType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "PhoneType");
        }
    }
}
