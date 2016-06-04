namespace TampaInnovation.DataAccess.Migrations.History
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingExtraField : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProviderResults", "ProviderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProviderResults", "ProviderId", c => c.String(maxLength: 250));
        }
    }
}
