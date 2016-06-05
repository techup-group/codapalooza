using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TampaInnovation.Business.Helpers;
using TampaInnovation.DataAccess;
using TampaInnovation.GeoLocation;
using TampaInnovation.GimmeServices;
using TampaInnovation.GimmeServices.Business;
using TampaInnovation.GimmeServices.Models;
using TampaInnovation.Models;
using Address = TampaInnovation.Models.Address;
using System.Data.Entity;
using Services = TampaInnovation.Models.Services;

namespace TampaInnovation.Business
{
    public class ResourcesServices
    {
        public static List<ServiceGeography> TestCall()
        {
            GimmeshelterClient client = new GimmeshelterClient();
            client.GetAddress<List<Address>>();
            client.GetAreasServed<List<AreaServered>>();
            client.GetBedUnitInventory<List<BedUnitInventory>>();
            client.GetContactNumbers<List<ContactNumber>>();
            client.GetGeography<List<Geography>>(33607);
            client.GetServices<List<GimmeServices.Models.Services>>();
            client.GetProviders<List<Provider>>();
            return client.GetServicesGeography<List<ServiceGeography>>(33607);
        }

        public static List<ProviderWrapper> Search(SearchRequest searchRequest)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                List<ProviderResult> providerResults = context.ProviderResult.Include(t => t.ContactInformations).Include(t => t.Addresses).Include(t => t.ProvidedServices).ToList();
                LatLong latLong;

                foreach (ProviderResult providerResult in providerResults)
                {
                    providerResult.ProvidedServices = providerResult.ProvidedServices.Distinct(new ServicesEquality()).ToList();
                }
                if (!searchRequest.Query.IsValidLatLong(out latLong))
                {
                    if (!string.IsNullOrEmpty(searchRequest.Query))
                    {
                        Models.GeoLocation latLongRequest = new GoogleGeoCoder().GetLatLong(searchRequest.Query);
                        latLong = new LatLong
                        {
                            Longitude = latLongRequest.Longitude,
                            Latitude = latLongRequest.Latitude
                        };
                    }
                }

                if (latLong == null)
                    throw new Exception("Invalid Query Provided");

                List<ProviderWrapper> providerWrappers = GeoLocations.GetProviderDistances(providerResults, latLong.Latitude, latLong.Longitude, searchRequest.Range);

                return providerWrappers.Take(searchRequest.Limit).ToList();
            }
        }

        public static ProviderResult Find(int providerId)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                return context.ProviderResult.Find(providerId);
            }
        }

        private class ServicesEquality : IEqualityComparer<Services>
        {
            public bool Equals(Services x, Services y)
            {
                return x.Name.Equals(y.Name);
            }

            public int GetHashCode(Services obj)
            {
                return obj.Name.GetHashCode();
            }
        }
    }
}
