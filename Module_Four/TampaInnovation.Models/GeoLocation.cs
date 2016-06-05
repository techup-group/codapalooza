namespace TampaInnovation.Models
{
    public class GeoLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Source { get; set; }
        public string SourceName { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}", Latitude, Longitude);
        }
    }
}