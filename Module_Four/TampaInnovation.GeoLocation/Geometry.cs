using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace TampaInnovation.GeoLocation
{
    [ExcludeFromCodeCoverage]
    public class Geometry
    {
        [JsonProperty("location")]
        public Location Location { get; set; }
    }
}
