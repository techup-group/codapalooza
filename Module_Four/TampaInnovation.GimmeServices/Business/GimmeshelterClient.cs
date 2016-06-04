using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace TampaInnovation.GimmeServices.Business
{
    public class GimmeshelterClient
    {
        private readonly string _baseUrl = "http://api.gimmeshelter.us/";

        private T CallApiGet<T>(string url)
        {
            using (HttpClient client = new HttpClient {BaseAddress = new Uri(_baseUrl)})
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
                    throw;
                }
                return default(T);
            }
        }

        public T GetAddress<T>()
        {
            string url = "gimmeshelter/Providers/getAddress?json=" + CreateJsonQueryString();
            return CallApiGet<T>(url);
        }

        public T GetAreasServed<T>()
        {
            string url = "gimmeshelter/Providers/getAreasServed?json=" + CreateJsonQueryString();
            return CallApiGet<T>(url);
        }

        public T GetBedUnitInventory<T>()
        {
            string url = "gimmeshelter/Providers/getBedUnitInventory?json=" + CreateJsonQueryString();
            return CallApiGet<T>(url);
        }

        public T GetContactNumbers<T>()
        {
            string url = "gimmeshelter/Providers/getContactNumbers?json=" + CreateJsonQueryString();
            return CallApiGet<T>(url);
        }

        public T GetGeography<T>(int zipCode)
        {
            string url = "gimmeshelter/Providers/getGeography?json=" + CreateJsonQueryStringWithZipCode(zipCode);
            return CallApiGet<T>(url);
        }

        public T GetProviders<T>()
        {
            string url = "gimmeshelter/Providers?json=" + CreateJsonQueryString();
            return CallApiGet<T>(url);
        }

        public T GetServices<T>()
        {
            string url = "gimmeshelter/Providers/getServices?json=" + CreateJsonQueryString();
            return CallApiGet<T>(url);
        }

        public T GetServicesGeography<T>(int zipCode)
        {
            string url = "gimmeshelter/Providers/getServicesGeography?json=" + CreateJsonQueryStringWithZipCode(zipCode);
            return CallApiGet<T>(url);
        }

        #region Private

        private static string CreateJsonQueryString()
        {
            SigningKey signingKey = Utilities.GetSigningKey(PUBLIC_KEY, PRIVATE_KEY);
            return "{\"ts\":\"" + signingKey.TimeStamp + "\",\"key\":\"" + signingKey.PublicKey + "\",\"sig\":\"" + signingKey.Signature + "\"}";
        }

        private static string CreateJsonQueryStringWithZipCode(int zipCode)
        {
            SigningKey signingKey = Utilities.GetSigningKey(PUBLIC_KEY, PRIVATE_KEY);

            return "{\"ts\": \"" + signingKey.TimeStamp + "\", \"sig\": \"" + signingKey.Signature + "\", \"key\": \"" + signingKey.PublicKey + "\", \"zip\": \"" + zipCode + "\"}";
        }


        private const string PUBLIC_KEY = "C2C1228EEDFCAB4DC1CAECCF8361A";
        private const string PRIVATE_KEY = "BFA429A2E243633954D9E17FB2646";

        #endregion
    }
}