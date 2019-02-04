namespace FCFAEFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeServiceName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "ServiceName", c => c.String(maxLength: 100));
            DropColumn("dbo.Services", "sName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "sName", c => c.String(maxLength: 100));
            DropColumn("dbo.Services", "ServiceName");
        }
    }
}
