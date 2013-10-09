namespace ApiSample.DA.Tables.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixGiftFieldError : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Gifts", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Gifts", "Name", c => c.Int(nullable: false));
        }
    }
}
