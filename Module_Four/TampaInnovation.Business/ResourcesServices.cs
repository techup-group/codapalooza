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

        public static List<ProviderWrapper> Search(List<string> filters, string query, int range, int limit)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                List<ProviderResult> providerResults = context.ProviderResult.Include(t => t.ContactInformations).Include(t => t.Addresses).ToList();
                LatLong latLong;
                if (!query.IsValidLatLong(out latLong))
                {
                    if (!string.IsNullOrEmpty(query))
                    {
                        Models.GeoLocation latLongRequest = new GoogleGeoCoder().GetLatLong(query);
                        latLong = new LatLong
                        {
                            Longitude = latLongRequest.Longitude,
                            Latitude = latLongRequest.Latitude
                        };
                    }
                }

                if (latLong == null)
                    throw new Exception("Invalid Query Provided");

                List<ProviderWrapper> providerWrappers = GeoLocations.GetProviderDistances(providerResults, latLong.Latitude, latLong.Longitude, range);

                return providerWrappers.Take(limit).ToList();
            }
        }

        public static ProviderResult Find(int providerId)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                return context.ProviderResult.Find(providerId);
            }
        }
    }
}
