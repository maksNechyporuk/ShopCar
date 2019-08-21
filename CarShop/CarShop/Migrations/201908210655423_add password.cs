namespace CarShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblClients", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblClients", "Password");
        }
    }
}
