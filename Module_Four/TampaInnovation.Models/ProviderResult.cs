using System.Collections.Generic;

namespace TampaInnovation.Models
{
    public class ProviderResult
    {
        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<ContactInformation> ContactInformations { get; set; } = new List<ContactInformation>();
        public string Name { get; set; }
        public List<string> ProvidedServices { get; set; } = new List<string>();
        public string ProviderId { get; set; }
        public string OperationHours { get; set; }
        public string AvailableUnits { get; set; }
        public string TotalUnits { get; set; }
    }
}