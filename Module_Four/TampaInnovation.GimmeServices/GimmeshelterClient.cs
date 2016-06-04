using System;
using System.Net;
using System.Net.Http;

namespace TampaInnovation.GimmeServices
{
    public class GimmeshelterClient
    {
        private string _baseUrl = " http://api.gimmeshelter.us/gimmeshelter/";

        public string GetProviders(string timeStamp, string key, string sig)
        {
            var jsonQueryString = "{'ts': '"+ timeStamp+"', 'sig': '" + sig + "', 'key': '"+ key+ "'}" ;
            var url = _baseUrl + "gimmeshelter/Providers?json=" + jsonQueryString;
            return CallApiGet(url);
        }

        private string CallApiGet(string url)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }

                if (response.StatusCode == HttpStatusCode.NotFound)
                    throw new Exception("Not found");

                string msg = response.Content.ReadAsStringAsync().Result;
                throw new Exception($"The following error occurred while retrieving order data from Api: {msg}");
            }

        }
    }
}
