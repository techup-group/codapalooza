using Newtonsoft.Json;

namespace TampaInnovation.GimmeServices.Business
{
    public class SigningKey
    {
        [JsonProperty("ts")]
        public string TimeStamp { get; set; }
        [JsonProperty("key")]
        public string PublicKey { get; set; }
        [JsonProperty("sig")]
        public string Signature { get; set; }
    }
}