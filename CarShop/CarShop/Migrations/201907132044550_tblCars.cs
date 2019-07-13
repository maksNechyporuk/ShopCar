namespace CarShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblCars : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblCars", "TypeId", "dbo.tblTypeCars");
            DropForeignKey("dbo.tblCars", "ModelId", "dbo.tblModels");
            DropForeignKey("dbo.tblCars", "FuelTypeId", "dbo.tblFuelTypes");
            DropForeignKey("dbo.tblCars", "ColorId", "dbo.tblColors");
            DropIndex("dbo.tblCars", new[] { "TypeId" });
            DropIndex("dbo.tblCars", new[] { "FuelTypeId" });
            DropIndex("dbo.tblCars", new[] { "ModelId" });
            DropIndex("dbo.tblCars", new[] { "ColorId" });
            DropTable("dbo.tblCars");
        }
    }
}
