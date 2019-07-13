namespace CarShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblFuelTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblFuelTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblFuelTypes");
        }
    }
}
