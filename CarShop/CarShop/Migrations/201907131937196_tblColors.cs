namespace CarShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblColors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblColors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        A = c.Int(nullable: false),
                        R = c.Int(nullable: false),
                        G = c.Int(nullable: false),
                        B = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblColors");
        }
    }
}
