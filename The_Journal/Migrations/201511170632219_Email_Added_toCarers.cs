namespace The_Journal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Email_Added_toCarers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carers", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carers", "Email");
        }
    }
}
