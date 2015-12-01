namespace The_Journal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sortingoutmaincarer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Families", "MainCarerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Families", "MainCarerID", c => c.Int(nullable: false));
        }
    }
}
