using System.Data.Entity.ModelConfiguration.Conventions;

namespace TampaInnovation.DataAccess
{
    public class StringConvention : Convention
    {
        public StringConvention()
        {
            Properties<string>().Configure(c => c.HasMaxLength(250));
        }
    }
}