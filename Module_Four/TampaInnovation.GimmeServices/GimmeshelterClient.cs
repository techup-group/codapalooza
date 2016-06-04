using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using TampaInnovation.Models;

namespace TampaInnovation.GimmeServices
{
    public class GimmeshelterClient
    {
        private string _baseUrl = "http://api.gimmeshelter.us/";

        private T CallApiGet<T>(string url)
        {
            using (HttpClient client = new HttpClient { BaseAddress = new Uri(_baseUrl) })
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResult = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<T>(jsonResult);
                    }

                    if (response.StatusCode == HttpStatusCode.NotFound)
                        throw new Exception("Not found");

                    string msg = response.Content.ReadAsStringAsync().Result;
                    throw new Exception($"The following error occurred while retrieving order data from Api: {msg}");
                }
                catch (Exception ex)
                {
                }
                return default(T);
            }
        }

        public T GetAddress<T>(SigningKey signingKey)
        {
            string url = "gimmeshelter/Providers/getAddress?json=" + CreateJsonQueryString(signingKey);
            return CallApiGet<T>(url);
        }

        public T GetAreasServed<T>(SigningKey signingKey)
        {
            string url = "gimmeshelter/Providers/getAreasServed?json=" + CreateJsonQueryString(signingKey);
            return CallApiGet<T>(url);
        }

        public T GetBedUnitInventory<T>(SigningKey signingKey)
        {
            string url = "gimmeshelter/Providers/getBedUnitInventory?json=" + CreateJsonQueryString(signingKey);
            return CallApiGet<T>(url);
        }

        public T GetContactNumbers<T>(SigningKey signingKey)
        {
            string url = "gimmeshelter/getContactNumbers?json=" + CreateJsonQueryString(signingKey);
            return CallApiGet<T>(url);
        }

        public T GetGeograpphy<T>(SigningKey signingKey, int zipCode)
        {
            string url = "gimmeshelter/Providers/getGeography?json=" + CreateJsonQueryStringWithZipCode(signingKey, zipCode);
            return CallApiGet<T>(url);
        }

        public T GetProviders<T>(SigningKey signingKey)
        {
            string url = "gimmeshelter/Providers?json=" + CreateJsonQueryString(signingKey);
            return CallApiGet<T>(url);
        }

        public T GetServices<T>(SigningKey signingKey)
        {
            string url = "gimmeshelter/Providers/getServices?json=" + CreateJsonQueryString(signingKey);
            return CallApiGet<T>(url);
        }

        public T GetServicesGeograpphy<T>(SigningKey signingKey, int zipCode)
        {
            string url = "gimmeshelter/Providers/getServicesGeography?json=" + CreateJsonQueryStringWithZipCode(signingKey, zipCode);
            return CallApiGet<T>(url);
        }

        #region Private
        
        private static string CreateJsonQueryString(SigningKey signingKey)
        {
            return "{\"ts\":\"" + signingKey.TimeStamp + "\",\"key\":\"" + signingKey.PublicKey + "\",\"sig\":\"" + signingKey.Signature + "\"}";
        }

        private static string CreateJsonQueryStringWithZipCode(SigningKey signingKey, int zipCode)
        {
            return "{\"ts\": \"" + signingKey.TimeStamp + "\", 'sig\": \"" + signingKey.Signature + "\", \"key\": \"" + signingKey.PublicKey + "\", \"zip}\": \"" + zipCode + "\"}";
        }

        #endregion
    }
}