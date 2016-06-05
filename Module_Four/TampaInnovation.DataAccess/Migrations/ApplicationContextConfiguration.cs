using System.Data.Entity.Migrations;

namespace TampaInnovation.DataAccess.Migrations
{
    public class ApplicationContextConfiguration : DbMigrationsConfiguration<ApplicationContext>
    {
        public ApplicationContextConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = "Migrations\\History";
            MigrationsNamespace = "TampaInnovation.DataAccess.Migrations.History";
        }
    }
}