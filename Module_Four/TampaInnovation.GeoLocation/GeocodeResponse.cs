using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace TampaInnovation.GeoLocation
{
    [ExcludeFromCodeCoverage]
    public class GeocodeResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("results")]
        public Results Results { get; set; }
    }
}
