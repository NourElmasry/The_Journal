namespace The_Journal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        ChildID = c.Int(nullable: false),
                        Room = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.Children", t => t.ChildID, cascadeDelete: true)
                .Index(t => t.ChildID);
            
            CreateTable(
                "dbo.Children",
                c => new
                    {
                        ChildID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        KnownName = c.String(),
                        Gender = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        SEN = c.String(),
                        FamilyID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        RoomID = c.Int(nullable: false),
                        Allergy = c.String(),
                    })
                .PrimaryKey(t => t.ChildID)
                .ForeignKey("dbo.Families", t => t.FamilyID, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomID, cascadeDelete: true)
                .Index(t => t.FamilyID)
                .Index(t => t.EmployeeID)
                .Index(t => t.RoomID);
            
            CreateTable(
                "dbo.Families",
                c => new
                    {
                        FamilyID = c.Int(nullable: false, identity: true),
                        ApplicationUserID = c.String(maxLength: 128),
                        MainCarer_CarerID = c.Int(),
                    })
                .PrimaryKey(t => t.FamilyID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .ForeignKey("dbo.Carers", t => t.MainCarer_CarerID)
                .Index(t => t.ApplicationUserID)
                .Index(t => t.MainCarer_CarerID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Carers",
                c => new
                    {
                        CarerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DOB = c.DateTime(nullable: false),
                        HomeNum = c.Int(nullable: false),
                        WorkNum = c.Int(nullable: false),
                        MobileNum = c.Int(nullable: false),
                        Address = c.String(),
                        PostCode = c.String(),
                        FamilyID = c.Int(nullable: false),
                        MainCarer = c.Boolean(nullable: false),
                        Family_FamilyID = c.Int(),
                        Family_FamilyID1 = c.Int(),
                    })
                .PrimaryKey(t => t.CarerID)
                .ForeignKey("dbo.Families", t => t.Family_FamilyID)
                .ForeignKey("dbo.Families", t => t.Family_FamilyID1)
                .Index(t => t.Family_FamilyID)
                .Index(t => t.Family_FamilyID1);
            
            CreateTable(
                "dbo.EmergencyContacts",
                c => new
                    {
                        EmergencyContactID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MobileNum = c.Int(nullable: false),
                        Relationship = c.String(),
                        Family_FamilyID = c.Int(),
                    })
                .PrimaryKey(t => t.EmergencyContactID)
                .ForeignKey("dbo.Families", t => t.Family_FamilyID)
                .Index(t => t.Family_FamilyID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        KnownName = c.String(),
                        Gender = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        RoomID = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Salary = c.Int(nullable: false),
                        MobileNum = c.Int(nullable: false),
                        OtherNum = c.Int(nullable: false),
                        Address = c.String(),
                        Session_SessionID = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Rooms", t => t.RoomID)
                .ForeignKey("dbo.Sessions", t => t.Session_SessionID)
                .Index(t => t.RoomID)
                .Index(t => t.Session_SessionID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        MaxNum = c.Int(nullable: false),
                        NumofChildren = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomID);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        SessionID = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        SessionRate = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        Booking_BookingID = c.Int(),
                    })
                .PrimaryKey(t => t.SessionID)
                .ForeignKey("dbo.Bookings", t => t.Booking_BookingID)
                .Index(t => t.Booking_BookingID);
            
            CreateTable(
                "dbo.DayJournals",
                c => new
                    {
                        DayJournalID = c.Int(nullable: false, identity: true),
                        ChildID = c.Int(nullable: false),
                        MealType = c.Int(),
                        MealName = c.String(),
                        Portion = c.Int(),
                        NapStart = c.DateTime(),
                        NapEnd = c.DateTime(),
                        Note = c.String(),
                        Portfolio_PortfolioID = c.Int(),
                    })
                .PrimaryKey(t => t.DayJournalID)
                .ForeignKey("dbo.Children", t => t.ChildID, cascadeDelete: true)
                .ForeignKey("dbo.Portfolios", t => t.Portfolio_PortfolioID)
                .Index(t => t.ChildID)
                .Index(t => t.Portfolio_PortfolioID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ChildID = c.Int(),
                        EmployeeID = c.Int(),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.Children", t => t.ChildID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID)
                .Index(t => t.ChildID)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.InvoiceLines",
                c => new
                    {
                        InvoiceLineID = c.Int(nullable: false, identity: true),
                        ChildID = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        SessionDate = c.DateTime(nullable: false),
                        Invoice_InvoiceID = c.Int(),
                    })
                .PrimaryKey(t => t.InvoiceLineID)
                .ForeignKey("dbo.Children", t => t.ChildID, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceID)
                .Index(t => t.ChildID)
                .Index(t => t.Invoice_InvoiceID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Total = c.Int(nullable: false),
                        FamilyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceID)
                .ForeignKey("dbo.Families", t => t.FamilyID, cascadeDelete: true)
                .Index(t => t.FamilyID);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        PicID = c.Int(nullable: false, identity: true),
                        Pic = c.Binary(),
                        ChildID = c.Int(nullable: false),
                        PicDescription = c.String(),
                        Portfolio_PortfolioID = c.Int(),
                    })
                .PrimaryKey(t => t.PicID)
                .ForeignKey("dbo.Children", t => t.ChildID, cascadeDelete: true)
                .ForeignKey("dbo.Portfolios", t => t.Portfolio_PortfolioID)
                .Index(t => t.ChildID)
                .Index(t => t.Portfolio_PortfolioID);
            
            CreateTable(
                "dbo.Portfolios",
                c => new
                    {
                        PortfolioID = c.Int(nullable: false, identity: true),
                        ChildID = c.Int(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.PortfolioID)
                .ForeignKey("dbo.Children", t => t.ChildID, cascadeDelete: true)
                .Index(t => t.ChildID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Pictures", "Portfolio_PortfolioID", "dbo.Portfolios");
            DropForeignKey("dbo.DayJournals", "Portfolio_PortfolioID", "dbo.Portfolios");
            DropForeignKey("dbo.Portfolios", "ChildID", "dbo.Children");
            DropForeignKey("dbo.Pictures", "ChildID", "dbo.Children");
            DropForeignKey("dbo.InvoiceLines", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "FamilyID", "dbo.Families");
            DropForeignKey("dbo.InvoiceLines", "ChildID", "dbo.Children");
            DropForeignKey("dbo.Events", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Events", "ChildID", "dbo.Children");
            DropForeignKey("dbo.DayJournals", "ChildID", "dbo.Children");
            DropForeignKey("dbo.Sessions", "Booking_BookingID", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "ChildID", "dbo.Children");
            DropForeignKey("dbo.Children", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.Children", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Session_SessionID", "dbo.Sessions");
            DropForeignKey("dbo.Employees", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.Families", "MainCarer_CarerID", "dbo.Carers");
            DropForeignKey("dbo.EmergencyContacts", "Family_FamilyID", "dbo.Families");
            DropForeignKey("dbo.Children", "FamilyID", "dbo.Families");
            DropForeignKey("dbo.Carers", "Family_FamilyID1", "dbo.Families");
            DropForeignKey("dbo.Carers", "Family_FamilyID", "dbo.Families");
            DropForeignKey("dbo.Families", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Portfolios", new[] { "ChildID" });
            DropIndex("dbo.Pictures", new[] { "Portfolio_PortfolioID" });
            DropIndex("dbo.Pictures", new[] { "ChildID" });
            DropIndex("dbo.Invoices", new[] { "FamilyID" });
            DropIndex("dbo.InvoiceLines", new[] { "Invoice_InvoiceID" });
            DropIndex("dbo.InvoiceLines", new[] { "ChildID" });
            DropIndex("dbo.Events", new[] { "EmployeeID" });
            DropIndex("dbo.Events", new[] { "ChildID" });
            DropIndex("dbo.DayJournals", new[] { "Portfolio_PortfolioID" });
            DropIndex("dbo.DayJournals", new[] { "ChildID" });
            DropIndex("dbo.Sessions", new[] { "Booking_BookingID" });
            DropIndex("dbo.Employees", new[] { "Session_SessionID" });
            DropIndex("dbo.Employees", new[] { "RoomID" });
            DropIndex("dbo.EmergencyContacts", new[] { "Family_FamilyID" });
            DropIndex("dbo.Carers", new[] { "Family_FamilyID1" });
            DropIndex("dbo.Carers", new[] { "Family_FamilyID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Families", new[] { "MainCarer_CarerID" });
            DropIndex("dbo.Families", new[] { "ApplicationUserID" });
            DropIndex("dbo.Children", new[] { "RoomID" });
            DropIndex("dbo.Children", new[] { "EmployeeID" });
            DropIndex("dbo.Children", new[] { "FamilyID" });
            DropIndex("dbo.Bookings", new[] { "ChildID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Portfolios");
            DropTable("dbo.Pictures");
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceLines");
            DropTable("dbo.Events");
            DropTable("dbo.DayJournals");
            DropTable("dbo.Sessions");
            DropTable("dbo.Rooms");
            DropTable("dbo.Employees");
            DropTable("dbo.EmergencyContacts");
            DropTable("dbo.Carers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Families");
            DropTable("dbo.Children");
            DropTable("dbo.Bookings");
        }
    }
}
