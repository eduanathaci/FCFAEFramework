namespace FCFAEFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Surname = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        Password = c.String(maxLength: 100),
                        PhoneNo = c.String(maxLength: 20),
                        PersonalNo = c.String(maxLength: 15),
                        Address = c.String(maxLength: 255),
                        Birthday = c.DateTime(nullable: false),
                        Gender = c.String(maxLength: 1),
                        IsActive = c.Boolean(nullable: false),
                        InsertDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Name = c.String(maxLength: 100),
                        ID = c.Int(nullable: false, identity: true),
                        Banner = c.String(maxLength: 255),
                        Description = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        CompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Email = c.String(maxLength: 255),
                        Password = c.String(maxLength: 100),
                        BusinessNo = c.Int(nullable: false),
                        FiscalNo = c.Int(nullable: false),
                        PhoneNo = c.String(maxLength: 20),
                        Address = c.String(maxLength: 255),
                        IsActive = c.Boolean(nullable: false),
                        InsertDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Consents",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        ServiceID = c.Int(nullable: false),
                        Purpose = c.String(),
                        InsertDate = c.DateTime(),
                        DataID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ID, t.ServiceID })
                .ForeignKey("dbo.Data", t => t.DataID, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceID, cascadeDelete: true)
                .Index(t => t.ServiceID)
                .Index(t => t.DataID);
            
            CreateTable(
                "dbo.Data",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NameOfData = c.String(maxLength: 100),
                        TypeOfData = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ServiceClients",
                c => new
                    {
                        Service_ID = c.Int(nullable: false),
                        Client_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Service_ID, t.Client_ID })
                .ForeignKey("dbo.Services", t => t.Service_ID, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.Client_ID, cascadeDelete: true)
                .Index(t => t.Service_ID)
                .Index(t => t.Client_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consents", "ServiceID", "dbo.Services");
            DropForeignKey("dbo.Consents", "DataID", "dbo.Data");
            DropForeignKey("dbo.Services", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.ServiceClients", "Client_ID", "dbo.Clients");
            DropForeignKey("dbo.ServiceClients", "Service_ID", "dbo.Services");
            DropIndex("dbo.ServiceClients", new[] { "Client_ID" });
            DropIndex("dbo.ServiceClients", new[] { "Service_ID" });
            DropIndex("dbo.Consents", new[] { "DataID" });
            DropIndex("dbo.Consents", new[] { "ServiceID" });
            DropIndex("dbo.Services", new[] { "CompanyID" });
            DropTable("dbo.ServiceClients");
            DropTable("dbo.Data");
            DropTable("dbo.Consents");
            DropTable("dbo.Companies");
            DropTable("dbo.Services");
            DropTable("dbo.Clients");
        }
    }
}
