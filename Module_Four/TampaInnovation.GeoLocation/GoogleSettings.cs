using System.Configuration;

namespace TampaInnovation.GeoLocation
{
    internal static class GoogleSettings
    {
        private static string _clientId;

        public static string ClientId
        {
            get
            {
                return _clientId ?? (_clientId = ConfigurationManager.AppSettings["Google.Key"]);
            }
        }
    }
}
