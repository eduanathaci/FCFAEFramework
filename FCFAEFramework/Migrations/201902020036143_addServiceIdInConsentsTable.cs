namespace FCFAEFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addServiceIdInConsentsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Consents", "ServiceID", c => c.Int(nullable: false));
            CreateIndex("dbo.Consents", "ServiceID");
            AddForeignKey("dbo.Consents", "ServiceID", "dbo.Services", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consents", "ServiceID", "dbo.Services");
            DropIndex("dbo.Consents", new[] { "ServiceID" });
            DropColumn("dbo.Consents", "ServiceID");
        }
    }
}
