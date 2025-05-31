namespace GPBH.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adddb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .Index(t => t.Name, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "Name" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
