namespace ApiSample.DA.Tables.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGift : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gifts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        Description = c.String(maxLength: 1000),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsValid = c.Boolean(nullable: false),
                        IdentifyKey = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GiftProducts",
                c => new
                    {
                        Gift_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Gift_Id, t.Product_Id })
                .ForeignKey("dbo.Gifts", t => t.Gift_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Gift_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.GiftProducts", new[] { "Product_Id" });
            DropIndex("dbo.GiftProducts", new[] { "Gift_Id" });
            DropForeignKey("dbo.GiftProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.GiftProducts", "Gift_Id", "dbo.Gifts");
            DropTable("dbo.GiftProducts");
            DropTable("dbo.Gifts");
        }
    }
}
