namespace TampaInnovation.DataAccess.Migrations.History
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRegistrations", "MarriageStatus", c => c.String(maxLength: 250));
            AlterColumn("dbo.UserRegistrations", "FamilyCount", c => c.String(maxLength: 250));
            DropColumn("dbo.UserRegistrations", "IsMarried");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserRegistrations", "IsMarried", c => c.Boolean(nullable: false));
            AlterColumn("dbo.UserRegistrations", "FamilyCount", c => c.Int(nullable: false));
            DropColumn("dbo.UserRegistrations", "MarriageStatus");
        }
    }
}
