using System.Collections.Generic;

namespace TampaInnovation.Models
{
    public class ProviderResult
    {
        public int Id { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<ContactInformation> ContactInformations { get; set; } = new List<ContactInformation>();
        public string Name { get; set; }
        public List<string> ProvidedServices { get; set; } = new List<string>();
        public string OperationHours { get; set; }
        public string AvailableUnits { get; set; }
        public string TotalUnits { get; set; }
    }
}