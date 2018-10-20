namespace PaYmate1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccount",
                c => new
                    {
                        BankAccountId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        AccountNumber = c.Int(nullable: false),
                        AccountBalance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.BankAccountId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        UserName = c.String(),
                        UserRole = c.Int(nullable: false),
                        BlockStatus = c.Int(nullable: false),
                        NIC = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        CardType = c.String(),
                        CardNumber = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        LogId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        TransactionType = c.String(),
                        Amount = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LogId);
            
            CreateTable(
                "dbo.PhoneBill",
                c => new
                    {
                        PhoneBillId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        BillAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PhoneBillId);
            
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        ReservationId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        RoomNumber = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationId);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        RoomNumber = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        RoomType = c.String(),
                    })
                .PrimaryKey(t => t.RoomId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Room");
            DropTable("dbo.Reservation");
            DropTable("dbo.PhoneBill");
            DropTable("dbo.Log");
            DropTable("dbo.Customer");
            DropTable("dbo.BankAccount");
        }
    }
}
