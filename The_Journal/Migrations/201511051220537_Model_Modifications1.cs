namespace The_Journal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model_Modifications1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceLines", "InvoiceID", c => c.Int(nullable: false));
            AlterColumn("dbo.Bookings", "Room", c => c.String());
            AlterColumn("dbo.Rooms", "Name", c => c.String());
            AlterColumn("dbo.Sessions", "Type", c => c.String());
            AlterColumn("dbo.Sessions", "Day", c => c.String());
            DropColumn("dbo.Rooms", "NumofChildren");
            DropColumn("dbo.Carers", "MainCarer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carers", "MainCarer", c => c.Boolean(nullable: false));
            AddColumn("dbo.Rooms", "NumofChildren", c => c.Int(nullable: false));
            AlterColumn("dbo.Sessions", "Day", c => c.Int(nullable: false));
            AlterColumn("dbo.Sessions", "Type", c => c.Int(nullable: false));
            AlterColumn("dbo.Rooms", "Name", c => c.Int(nullable: false));
            AlterColumn("dbo.Bookings", "Room", c => c.Int(nullable: false));
            DropColumn("dbo.InvoiceLines", "InvoiceID");
        }
    }
}
