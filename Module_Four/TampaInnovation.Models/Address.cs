namespace TampaInnovation.Models
{
    public class Address
    {
        public string AddressType { get; set; }
        public string AddressId { get; set; }
        public bool IsActive { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Landmarks { get; set; }
        public double? Latitude { get; set; }
        public string StreetAddress { get; set; }
        public string Additional { get; set; }
        public double? Longitude { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
    }
}