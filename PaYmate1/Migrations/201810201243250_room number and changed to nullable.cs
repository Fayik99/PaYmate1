namespace PaYmate1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roomnumberandchangedtonullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservation", "RoomNumber", c => c.Int());
            AlterColumn("dbo.Reservation", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservation", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Reservation", "RoomNumber", c => c.Int(nullable: false));
        }
    }
}
