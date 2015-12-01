namespace The_Journal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMainCarerback : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Families", "MainCarerID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Families", "MainCarerID");
        }
    }
}
