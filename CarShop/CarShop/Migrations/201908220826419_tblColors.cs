namespace CarShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblColors : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblModels", "MakeId", "dbo.tblMakes");
            DropIndex("dbo.tblModels", new[] { "MakeId" });
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Availability = c.Boolean(nullable: false),
                        Type = c.String(),
                        FuelType = c.String(),
                        Model = c.String(),
                        Make = c.String(),
                        Price = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        PathImg = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblClients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Total_price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.tblColors", "Name", c => c.String(nullable: false));
            DropTable("dbo.tblMakes");
            DropTable("dbo.tblModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tblModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MakeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblMakes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.tblColors", "Name");
            DropTable("dbo.tblClients");
            DropTable("dbo.Cars");
            CreateIndex("dbo.tblModels", "MakeId");
            AddForeignKey("dbo.tblModels", "MakeId", "dbo.tblMakes", "Id", cascadeDelete: true);
        }
    }
}
