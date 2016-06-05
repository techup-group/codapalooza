using System;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace TampaInnovation.GeoLocation
{
    public class GoogleGeoCoder
    {
        public Models.GeoLocation GetLatLong(string address)
        {
            GeocodeResponse response = GetResponse(address);
            if (response == null
                || response.Status != "OK"
                || response.Results == null
                || response.Results.Count == 0
                || response.Results[0].Geometry == null
                || response.Results[0].Geometry.Location == null
                || response.Results[0].Geometry.Location.Lat == 0
                || response.Results[0].Geometry.Location.Lng == 0)
            {
                return null;
            }

            GeoPointSource source = GeoPointSource.Unknown;
            string sourceName = null;
            if (response.Results[0].Types != null)
            {
                if (response.Results[0].Types.Contains("postal_code"))
                {
                    source = GeoPointSource.PostalCode;
                    sourceName = GetSourceName(response.Results[0].AddressComponents, "postal_code");
                }
                else if (response.Results[0].Types.Contains("administrative_area_level_1"))
                {
                    // state
                    source = GeoPointSource.State;
                    sourceName = GetSourceName(response.Results[0].AddressComponents, "administrative_area_level_1");
                }
                else if (response.Results[0].Types.Contains("street_address"))
                {
                    source = GeoPointSource.StreetAddress;
                    sourceName = GetSourceName(response.Results[0].AddressComponents, "street_address");
                }
                else if (response.Results[0].Types.Contains("locality"))
                {
                    source = GeoPointSource.City;
                    sourceName = GetSourceName(response.Results[0].AddressComponents, "locality");

                    string state = GetSourceName(response.Results[0].AddressComponents, "administrative_area_level_1");
                    if (state != null)
                    {
                        source = GeoPointSource.CityState;
                        sourceName += "," + state;
                    }
                }
            }

            return new Models.GeoLocation
            {
                Latitude = response.Results[0].Geometry.Location.Lat,
                Longitude = response.Results[0].Geometry.Location.Lng,
                Source = source.ToString(),
                SourceName = sourceName
            };
        }

        public GeocodeResponse GetEnterpriseGeocodeResponse(string address)
        {
            using (HttpClient client = new HttpClient {BaseAddress = new Uri("https://maps.googleapis.com/") })
            {
                try
                {
                    string encodedAddress = WebUtility.UrlEncode(address);
                    string operation = $"/maps/api/geocode/json?address={encodedAddress}&key={GoogleSettings.ClientId}";

                    HttpResponseMessage response = client.GetAsync(operation).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResult = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<GeocodeResponse>(jsonResult);
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        private GeocodeResponse GetResponse(string address)
        {
            return GetEnterpriseGeocodeResponse(address);
        }

        private static string GetSourceName(AddressComponents addressComponents, string type)
        {
            // go through the address components and if a match to type is found, return the short name.
            // for example, if the source is a state, the source name would be the short name for the state (2 letter code).
            if (addressComponents != null)
            {
                foreach (AddressComponent component in addressComponents)
                {
                    if (component.Types != null && component.Types.Contains(type))
                        return component.ShortName;
                }
            }
            return string.Empty;
        }
    }
}