namespace ApiSample.DA.Tables.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSystemInfoField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CreatedBy", c => c.String());
            AddColumn("dbo.Categories", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Categories", "UpdatedBy", c => c.String());
            AddColumn("dbo.Categories", "UpdatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "CreatedBy", c => c.String());
            AddColumn("dbo.Products", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "UpdatedBy", c => c.String());
            AddColumn("dbo.Products", "UpdatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "UpdatedAt");
            DropColumn("dbo.Products", "UpdatedBy");
            DropColumn("dbo.Products", "CreatedAt");
            DropColumn("dbo.Products", "CreatedBy");
            DropColumn("dbo.Categories", "UpdatedAt");
            DropColumn("dbo.Categories", "UpdatedBy");
            DropColumn("dbo.Categories", "CreatedAt");
            DropColumn("dbo.Categories", "CreatedBy");
        }
    }
}
