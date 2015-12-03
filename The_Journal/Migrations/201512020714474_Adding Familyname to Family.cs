namespace The_Journal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingFamilynametoFamily : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Families", "FamilyName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Families", "FamilyName");
        }
    }
}
