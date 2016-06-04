namespace TampaInnovation.Models
{
    public class ContactInformation
    {
        public string ContactType { get; set; }
        public string ContactId { get; set; }
        public bool IsActive { get; set; }
        public string ContactName { get; set; }
        public string Number { get; set; }
        public string TelephoneAreaCode { get; set; }
        public string TelephoneExtension { get; set; }
        public string TelephoneLine { get; set; }
        public string TelephonePrefix { get; set; }
    }
}