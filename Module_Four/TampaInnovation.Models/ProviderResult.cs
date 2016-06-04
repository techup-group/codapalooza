using System.Collections.Generic;

namespace TampaInnovation.Models
{
    public class ProviderResult
    {
        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<ContactInformation> ContactInformations { get; set; } = new List<ContactInformation>();
        public List<ContactPersonnel> ContactPeople { get; set; } = new List<ContactPersonnel>();
        public string Name { get; set; }
        public List<string> ProvidedServices { get; set; } = new List<string>();
        public string ProviderId { get; set; }
    }
}