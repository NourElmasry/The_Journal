namespace The_Journal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model_Modifications : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carers", "Family_FamilyID1", "dbo.Families");
            DropForeignKey("dbo.Families", "MainCarer_CarerID", "dbo.Carers");
            DropForeignKey("dbo.Sessions", "Booking_BookingID", "dbo.Bookings");
            DropForeignKey("dbo.InvoiceLines", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.DayJournals", "Portfolio_PortfolioID", "dbo.Portfolios");
            DropForeignKey("dbo.Pictures", "Portfolio_PortfolioID", "dbo.Portfolios");
            DropForeignKey("dbo.Carers", "Family_FamilyID", "dbo.Families");
            DropForeignKey("dbo.EmergencyContacts", "Family_FamilyID", "dbo.Families");
            DropIndex("dbo.Families", new[] { "MainCarer_CarerID" });
            DropIndex("dbo.Carers", new[] { "Family_FamilyID" });
            DropIndex("dbo.Carers", new[] { "Family_FamilyID1" });
            DropIndex("dbo.EmergencyContacts", new[] { "Family_FamilyID" });
            DropIndex("dbo.Sessions", new[] { "Booking_BookingID" });
            DropIndex("dbo.DayJournals", new[] { "Portfolio_PortfolioID" });
            DropIndex("dbo.InvoiceLines", new[] { "Invoice_InvoiceID" });
            DropIndex("dbo.Pictures", new[] { "Portfolio_PortfolioID" });
            DropColumn("dbo.Carers", "FamilyID");
            RenameColumn(table: "dbo.Carers", name: "Family_FamilyID", newName: "FamilyID");
            RenameColumn(table: "dbo.EmergencyContacts", name: "Family_FamilyID", newName: "FamilyID");
            AddColumn("dbo.Families", "MainCarerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Carers", "FamilyID", c => c.Int(nullable: false));
            AlterColumn("dbo.EmergencyContacts", "FamilyID", c => c.Int(nullable: false));
            CreateIndex("dbo.Carers", "FamilyID");
            CreateIndex("dbo.EmergencyContacts", "FamilyID");
            AddForeignKey("dbo.Carers", "FamilyID", "dbo.Families", "FamilyID", cascadeDelete: true);
            AddForeignKey("dbo.EmergencyContacts", "FamilyID", "dbo.Families", "FamilyID", cascadeDelete: true);
            DropColumn("dbo.Families", "MainCarer_CarerID");
            DropColumn("dbo.Carers", "Family_FamilyID1");
            DropColumn("dbo.Sessions", "Booking_BookingID");
            DropColumn("dbo.DayJournals", "Portfolio_PortfolioID");
            DropColumn("dbo.InvoiceLines", "Invoice_InvoiceID");
            DropColumn("dbo.Pictures", "Portfolio_PortfolioID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pictures", "Portfolio_PortfolioID", c => c.Int());
            AddColumn("dbo.InvoiceLines", "Invoice_InvoiceID", c => c.Int());
            AddColumn("dbo.DayJournals", "Portfolio_PortfolioID", c => c.Int());
            AddColumn("dbo.Sessions", "Booking_BookingID", c => c.Int());
            AddColumn("dbo.Carers", "Family_FamilyID1", c => c.Int());
            AddColumn("dbo.Families", "MainCarer_CarerID", c => c.Int());
            DropForeignKey("dbo.EmergencyContacts", "FamilyID", "dbo.Families");
            DropForeignKey("dbo.Carers", "FamilyID", "dbo.Families");
            DropIndex("dbo.EmergencyContacts", new[] { "FamilyID" });
            DropIndex("dbo.Carers", new[] { "FamilyID" });
            AlterColumn("dbo.EmergencyContacts", "FamilyID", c => c.Int());
            AlterColumn("dbo.Carers", "FamilyID", c => c.Int());
            DropColumn("dbo.Families", "MainCarerID");
            RenameColumn(table: "dbo.EmergencyContacts", name: "FamilyID", newName: "Family_FamilyID");
            RenameColumn(table: "dbo.Carers", name: "FamilyID", newName: "Family_FamilyID");
            AddColumn("dbo.Carers", "FamilyID", c => c.Int(nullable: false));
            CreateIndex("dbo.Pictures", "Portfolio_PortfolioID");
            CreateIndex("dbo.InvoiceLines", "Invoice_InvoiceID");
            CreateIndex("dbo.DayJournals", "Portfolio_PortfolioID");
            CreateIndex("dbo.Sessions", "Booking_BookingID");
            CreateIndex("dbo.EmergencyContacts", "Family_FamilyID");
            CreateIndex("dbo.Carers", "Family_FamilyID1");
            CreateIndex("dbo.Carers", "Family_FamilyID");
            CreateIndex("dbo.Families", "MainCarer_CarerID");
            AddForeignKey("dbo.EmergencyContacts", "Family_FamilyID", "dbo.Families", "FamilyID");
            AddForeignKey("dbo.Carers", "Family_FamilyID", "dbo.Families", "FamilyID");
            AddForeignKey("dbo.Pictures", "Portfolio_PortfolioID", "dbo.Portfolios", "PortfolioID");
            AddForeignKey("dbo.DayJournals", "Portfolio_PortfolioID", "dbo.Portfolios", "PortfolioID");
            AddForeignKey("dbo.InvoiceLines", "Invoice_InvoiceID", "dbo.Invoices", "InvoiceID");
            AddForeignKey("dbo.Sessions", "Booking_BookingID", "dbo.Bookings", "BookingID");
            AddForeignKey("dbo.Families", "MainCarer_CarerID", "dbo.Carers", "CarerID");
            AddForeignKey("dbo.Carers", "Family_FamilyID1", "dbo.Families", "FamilyID");
        }
    }
}
