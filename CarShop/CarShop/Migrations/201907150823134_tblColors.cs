namespace CarShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblColors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblColors", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblColors", "Name");
        }
    }
}
