using System;
using System.Net;
using System.Net.Http;

namespace TampaInnovation.GimmeServices
{
    public class GimmeshelterClient
    {
        private string _baseUrl = "http://api.gimmeshelter.us/gimmeshelter/";

        public string GetProviders(string timeStamp, string key, string sig)
        {
            var url = _baseUrl + "gimmeshelter/Providers?json=" + CreateJsonQueryString(timeStamp, key, sig);
            return CallApiGet(url);
        }

        public string GetContactNumbers(string timeStamp, string key, string sig)
        {
            var url = _baseUrl + "gimmeshelter/getContactNumbers?json=" + CreateJsonQueryString(timeStamp, key, sig);
            return CallApiGet(url);
        }

        public string GetAddress(string timeStamp, string key, string sig)
        {
            var url = _baseUrl + "gimmeshelter/Providers/getAddress?json=" + CreateJsonQueryString(timeStamp, key, sig);
            return CallApiGet(url);
        }

        public string GetAreasServed(string timeStamp, string key, string sig)
        {
            var url = _baseUrl + "gimmeshelter/Providers/getAreasServed?json=" + CreateJsonQueryString(timeStamp, key, sig);
            return CallApiGet(url);
        }

        public string GetServices(string timeStamp, string key, string sig)
        {
            var url = _baseUrl + "gimmeshelter/Providers/getServices?json=" + CreateJsonQueryString(timeStamp, key, sig);
            return CallApiGet(url);
        }

        public string GetGeograpphy(string timeStamp, string key, string sig, string zipCode)
        {
            var url = _baseUrl + "gimmeshelter/Providers/getGeography?json=" + CreateJsonQueryStringWithZipCode(timeStamp, key, sig, zipCode);
            return CallApiGet(url);
        }

        public string GetServicesGeograpphy(string timeStamp, string key, string sig, string zipCode)
        {
            var url = _baseUrl + "gimmeshelter/Providers/getServicesGeography?json=" + CreateJsonQueryStringWithZipCode(timeStamp, key, sig, zipCode);
            return CallApiGet(url);
        }

        public string GetBedUnitInventory(string timeStamp, string key, string sig)
        {
            var url = _baseUrl + "gimmeshelter/Providers/getBedUnitInventory?json=" + CreateJsonQueryString(timeStamp, key, sig);
            return CallApiGet(url);
        }

   
        #region Private Methods
        private string CreateJsonQueryString(string timeStamp, string key, string sig)
        {
            return "{\"ts\": \"" + timeStamp + "\", 'sig\": \"" + sig + "\", \"key\": \"" + key + "\"}";
        }

        private string CreateJsonQueryStringWithZipCode(string timeStamp, string key, string sig, string zipCode)
        {
            return "{\"ts\": \"" + timeStamp + "\", 'sig\": \"" + sig + "\", \"key\": \"" + key + "\", \"zip}\": \"" + zipCode + "\"}";
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
                throw new Exception($"The following error occurred while retrieving provider data from Api: {msg}");
            }

        }

        #endregion
    }
}
