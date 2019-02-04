namespace FCFAEFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondCommit : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Consents");
            AlterColumn("dbo.Consents", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Consents", new[] { "ID", "ServiceID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Consents");
            AlterColumn("dbo.Consents", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Consents", new[] { "ID", "ServiceID" });
        }
    }
}
