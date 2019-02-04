namespace FCFAEFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdCommit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "sName", c => c.String(maxLength: 100));
            DropColumn("dbo.Services", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "Name", c => c.String(maxLength: 100));
            DropColumn("dbo.Services", "sName");
        }
    }
}
