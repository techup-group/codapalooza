namespace TampaInnovation.GimmeServices.Models
{
    public class Services
    {
        public string Active { get; set; }
        public string IsThisAMedicaidBillableItem { get; set; }
        public string DateAdded { get; set; }
        public string DateUpdated { get; set; }
        public string Name { get; set; }
        public string ProviderCreating { get; set; }
        public string Provider { get; set; }
        public string ProviderSpecificServiceID { get; set; }
        public string ProviderUpdating { get; set; }
        public string RequiresPreAuthorization { get; set; }
        public string DefaultUnitCost { get; set; }
        public string UnitType { get; set; }
    }
}