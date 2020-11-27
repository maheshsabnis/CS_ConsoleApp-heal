namespace MVC_Complete_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryRowId = c.Int(nullable: false, identity: true),
                        CategoryId = c.String(nullable: false, maxLength: 50),
                        CategoryName = c.String(nullable: false, maxLength: 200),
                        BasePrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryRowId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductRowId = c.Int(nullable: false, identity: true),
                        ProductId = c.String(nullable: false, maxLength: 50),
                        ProductName = c.String(nullable: false, maxLength: 200),
                        Manufacturer = c.String(nullable: false, maxLength: 300),
                        Description = c.String(nullable: false, maxLength: 500),
                        CategoryRowId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductRowId)
                .ForeignKey("dbo.Categories", t => t.CategoryRowId, cascadeDelete: true)
                .Index(t => t.CategoryRowId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryRowId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryRowId" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
