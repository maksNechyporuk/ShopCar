namespace CarShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblMakes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblMakes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MakeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblMakes", t => t.MakeId, cascadeDelete: true)
                .Index(t => t.MakeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblModels", "MakeId", "dbo.tblMakes");
            DropIndex("dbo.tblModels", new[] { "MakeId" });
            DropTable("dbo.tblModels");
            DropTable("dbo.tblMakes");
        }
    }
}
