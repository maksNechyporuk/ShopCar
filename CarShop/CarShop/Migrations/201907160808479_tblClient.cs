namespace CarShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblClient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblClients", "Phone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblClients", "Phone");
        }
    }
}
