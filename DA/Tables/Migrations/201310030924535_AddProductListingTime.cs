namespace ApiSample.DA.Tables.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductListingTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ListingStartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "ListingEndTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ListingEndTime");
            DropColumn("dbo.Products", "ListingStartTime");
        }
    }
}
