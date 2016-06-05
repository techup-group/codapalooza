namespace TampaInnovation.DataAccess.Migrations.History
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressType = c.String(maxLength: 250),
                        City = c.String(maxLength: 250),
                        Country = c.String(maxLength: 250),
                        Landmarks = c.String(maxLength: 250),
                        Latitude = c.Double(),
                        StreetAddress = c.String(maxLength: 250),
                        Additional = c.String(maxLength: 250),
                        Longitude = c.Double(),
                        ZipCode = c.String(maxLength: 250),
                        State = c.String(maxLength: 250),
                        ProviderResult_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProviderResults", t => t.ProviderResult_Id)
                .Index(t => t.ProviderResult_Id);
            
            CreateTable(
                "dbo.ContactInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Number = c.String(maxLength: 250),
                        Extension = c.String(maxLength: 250),
                        ProviderResult_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProviderResults", t => t.ProviderResult_Id)
                .Index(t => t.ProviderResult_Id);
            
            CreateTable(
                "dbo.ProviderResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        OperationHours = c.String(maxLength: 250),
                        AvailableUnits = c.String(maxLength: 250),
                        TotalUnits = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        ProviderResult_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProviderResults", t => t.ProviderResult_Id)
                .Index(t => t.ProviderResult_Id);
            
            CreateTable(
                "dbo.UserRegistrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 250),
                        LastName = c.String(maxLength: 250),
                        Email = c.String(maxLength: 250),
                        Phone = c.String(maxLength: 250),
                        Gender = c.String(maxLength: 250),
                        IsMarried = c.Boolean(nullable: false),
                        FamilyCount = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "ProviderResult_Id", "dbo.ProviderResults");
            DropForeignKey("dbo.ContactInformations", "ProviderResult_Id", "dbo.ProviderResults");
            DropForeignKey("dbo.Addresses", "ProviderResult_Id", "dbo.ProviderResults");
            DropIndex("dbo.Services", new[] { "ProviderResult_Id" });
            DropIndex("dbo.ContactInformations", new[] { "ProviderResult_Id" });
            DropIndex("dbo.Addresses", new[] { "ProviderResult_Id" });
            DropTable("dbo.UserRegistrations");
            DropTable("dbo.Services");
            DropTable("dbo.ProviderResults");
            DropTable("dbo.ContactInformations");
            DropTable("dbo.Addresses");
        }
    }
}
