using System.Collections.Generic;
using Newtonsoft.Json;

namespace TampaInnovation.Models
{
    public class SearchRequest
    {
        public SearchRequest()
        {
            Filters = new List<string>();
            Range = 10;
            Limit = 30;
        }

        [JsonProperty("filters")]
        public List<string> Filters { get; set; }
        [JsonProperty("query")]
        public string Query { get; set; }
        [JsonProperty("range")]
        public int Range { get; set; }
        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
}