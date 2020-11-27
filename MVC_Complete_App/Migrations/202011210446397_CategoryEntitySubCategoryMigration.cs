namespace MVC_Complete_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryEntitySubCategoryMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "SubCategoryName", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "SubCategoryName");
        }
    }
}
