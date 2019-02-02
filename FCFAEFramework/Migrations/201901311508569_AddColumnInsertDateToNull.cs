namespace FCFAEFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnInsertDateToNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "InsertDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "InsertDate", c => c.DateTime(nullable: false));
        }
    }
}
