namespace The_Journal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enums_to_strings : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Children", "Gender", c => c.String());
            AlterColumn("dbo.Employees", "Gender", c => c.String());
            AlterColumn("dbo.Employees", "Type", c => c.String());
            AlterColumn("dbo.DayJournals", "MealType", c => c.String());
            AlterColumn("dbo.DayJournals", "Portion", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DayJournals", "Portion", c => c.Int());
            AlterColumn("dbo.DayJournals", "MealType", c => c.Int());
            AlterColumn("dbo.Employees", "Type", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "Gender", c => c.Int(nullable: false));
            AlterColumn("dbo.Children", "Gender", c => c.Int(nullable: false));
        }
    }
}
