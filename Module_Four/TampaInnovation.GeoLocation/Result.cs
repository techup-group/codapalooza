using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace TampaInnovation.GeoLocation
{
    [ExcludeFromCodeCoverage]
    public class Result
    {
        [JsonProperty("address_components")]
        public AddressComponents AddressComponents { get; set; }

        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }

        [JsonProperty("types")]
        public List<String> Types { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class Results : List<Result>
    {
    }
}
