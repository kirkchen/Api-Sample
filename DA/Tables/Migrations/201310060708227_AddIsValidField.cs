namespace ApiSample.DA.Tables.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsValidField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "IsValid", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "IsValid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "IsValid");
            DropColumn("dbo.Categories", "IsValid");
        }
    }
}
