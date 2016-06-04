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

        public static List<ProviderContact> TestCall()
        {
            GimmeshelterClient client = new GimmeshelterClient();
            var key = Utilities.GetSigningKey(publicKey, privateKey);
            client.GetAddress<string>(key);
            client.GetAreasServed<string>(key);
            client.GetBedUnitInventory<string>(key);
            client.GetContactNumbers<string>(key);
            client.GetGeograpphy<string>(key, 33607);
            client.GetServices<string>(key);
            client.GetServicesGeograpphy<string>(key, 33607);
            return client.GetProviders<List<ProviderContact>>(Utilities.GetSigningKey(publicKey, privateKey));
        }
    }
}
