namespace ApiSample.DA.Tables.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuditLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentifyKey = c.Guid(nullable: false),
                        IdentifyName = c.String(),
                        OriginValue = c.String(),
                        NewValue = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Categories", "IdentifyKey", c => c.Guid(nullable: false));
            AddColumn("dbo.Products", "IdentifyKey", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "IdentifyKey");
            DropColumn("dbo.Categories", "IdentifyKey");
            DropTable("dbo.AuditLogs");
        }
    }
}
