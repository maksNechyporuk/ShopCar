namespace CarShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblPurchase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblClients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Image = c.String(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblPurchase", "OrderId", "dbo.tblOrders");
            DropForeignKey("dbo.tblOrders", "ClientId", "dbo.tblClients");
            DropForeignKey("dbo.tblOrders", "CarId", "dbo.tblCars");
            DropIndex("dbo.tblPurchase", new[] { "OrderId" });
            DropIndex("dbo.tblOrders", new[] { "ClientId" });
            DropIndex("dbo.tblOrders", new[] { "CarId" });
            DropTable("dbo.tblPurchase");
            DropTable("dbo.tblOrders");
            DropTable("dbo.tblClients");
        }
    }
}
