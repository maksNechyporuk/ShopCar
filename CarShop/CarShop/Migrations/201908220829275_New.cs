namespace CarShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ColorId = c.Int(nullable: false),
                        ModelId = c.Int(nullable: false),
                        FuelTypeId = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                        Image = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblColors", t => t.ColorId, cascadeDelete: true)
                .ForeignKey("dbo.tblFuelTypes", t => t.FuelTypeId, cascadeDelete: true)
                .ForeignKey("dbo.tblModels", t => t.ModelId, cascadeDelete: true)
                .ForeignKey("dbo.tblTypeCars", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.ColorId)
                .Index(t => t.ModelId)
                .Index(t => t.FuelTypeId)
                .Index(t => t.TypeId);
            
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
            
            CreateTable(
                "dbo.tblOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Price = c.Single(nullable: false),
                        CarId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.tblClients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.CarId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.tblPurchase",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblOrders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            AddColumn("dbo.tblColors", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblPurchase", "OrderId", "dbo.tblOrders");
            DropForeignKey("dbo.tblOrders", "ClientId", "dbo.tblClients");
            DropForeignKey("dbo.tblOrders", "CarId", "dbo.tblCars");
            DropForeignKey("dbo.tblCars", "TypeId", "dbo.tblTypeCars");
            DropForeignKey("dbo.tblCars", "ModelId", "dbo.tblModels");
            DropForeignKey("dbo.tblCars", "FuelTypeId", "dbo.tblFuelTypes");
            DropForeignKey("dbo.tblCars", "ColorId", "dbo.tblColors");
            DropIndex("dbo.tblPurchase", new[] { "OrderId" });
            DropIndex("dbo.tblOrders", new[] { "ClientId" });
            DropIndex("dbo.tblOrders", new[] { "CarId" });
            DropIndex("dbo.tblCars", new[] { "TypeId" });
            DropIndex("dbo.tblCars", new[] { "FuelTypeId" });
            DropIndex("dbo.tblCars", new[] { "ModelId" });
            DropIndex("dbo.tblCars", new[] { "ColorId" });
            DropColumn("dbo.tblColors", "Name");
            DropTable("dbo.tblPurchase");
            DropTable("dbo.tblOrders");
            DropTable("dbo.tblClients");
            DropTable("dbo.tblCars");
        }
    }
}
