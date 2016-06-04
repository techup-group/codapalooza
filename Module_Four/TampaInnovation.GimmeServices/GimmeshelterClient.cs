using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TampaInnovation.Models;

namespace TampaInnovation.GimmeServices
{
    public class GimmeshelterClient
    {
        private string _baseUrl = "http://api.gimmeshelter.us/gimmeshelter/";

        public List<ProviderContact> GetProviders(SigningKey signingKey)
        {
            var json = "{\"ts\":\"" + signingKey.TimeStamp + "\",\"key\":\""+ signingKey.PublicKey + "\",\"sig\":\"" + signingKey.Signature + "\"}";
            var url = _baseUrl + "Providers/getContactNumbers?json=" + json;
            return CallApiGet(url);
        }

        private List<ProviderContact> CallApiGet(string url)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = client.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResult = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<List<ProviderContact>>(jsonResult);
                    }

                    if (response.StatusCode == HttpStatusCode.NotFound)
                        throw new Exception("Not found");

                    string msg = response.Content.ReadAsStringAsync().Result;
                    throw new Exception($"The following error occurred while retrieving order data from Api: {msg}");
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

        }
    }
}
