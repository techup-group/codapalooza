using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TampaInnovation.Business.Helpers;

namespace TampaInnovation.Business
{
    public class ResourcesServices
    {
        public static string TestServices()
        {
            string publicKey = "C2C1228EEDFCAB4DC1CAECCF8361A";
            string privateKey = "BFA429A2E243633954D9E17FB2646";
            return  JsonConvert.SerializeObject(Utilities.GetSigningKey(publicKey, privateKey));
        }
    }
}
