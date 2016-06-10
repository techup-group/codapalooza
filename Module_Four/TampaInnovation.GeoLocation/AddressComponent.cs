using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace TampaInnovation.GeoLocation
{
    [ExcludeFromCodeCoverage]
    public class AddressComponent
    {
        [JsonProperty("long_name")]
        public String LongName { get; set; }

        [JsonProperty("short_name")]
        public String ShortName { get; set; }

        [JsonProperty("types")]
        public List<String> Types { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AddressComponents : List<AddressComponent>
    {
    }
}