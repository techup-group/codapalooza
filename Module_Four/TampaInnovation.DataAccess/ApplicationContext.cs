using System.Data.Entity;
using TampaInnovation.DataAccess.Migrations;
using TampaInnovation.Models;

namespace TampaInnovation.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationContext, ApplicationContextConfiguration>());
        }

        public DbSet<ProviderResult> ProviderResult { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<ContactInformation> ContactInformation { get; set; }
        public DbSet<UserRegistration> UserRegistrations { get; set; }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new StringConvention());
            base.OnModelCreating(modelBuilder);
        }
    }
}