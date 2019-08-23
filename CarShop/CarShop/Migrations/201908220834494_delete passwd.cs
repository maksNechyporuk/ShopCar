namespace CarShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletepasswd : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tblClients", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblClients", "Password", c => c.String(nullable: false));
        }
    }
}
