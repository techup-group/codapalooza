using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TampaInnovation.Business.Helpers;
using TampaInnovation.GimmeServices;
using TampaInnovation.Models;

namespace TampaInnovation.Business
{
    public class ResourcesServices
    {
        static string publicKey = "C2C1228EEDFCAB4DC1CAECCF8361A";
        static string privateKey = "BFA429A2E243633954D9E17FB2646";

        public static string TestServices()
        {
            return JsonConvert.SerializeObject(Utilities.GetSigningKey(publicKey, privateKey));
        }

        public static List<ServiceGeography> TestCall()
        {
            GimmeshelterClient client = new GimmeshelterClient();
            var key = Utilities.GetSigningKey(publicKey, privateKey);
            client.GetAddress<List<Address>>(key);
            client.GetAreasServed<List<AreaServered>>(key);
            client.GetBedUnitInventory<List<BedUnitInventory>>(key);
            client.GetContactNumbers<List<ContactNumber>>(key);
            client.GetGeography<List<Geography>>(key, 33607);
            client.GetServices<List<Services>>(key);
            client.GetProviders<List<Provider>>(key);
            return client.GetServicesGeography<List<ServiceGeography>>(key, 33607);
        }
    }
}
