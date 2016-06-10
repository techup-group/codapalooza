using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TampaInnovation.Models;

namespace TampaInnovation.Business.Helpers
{
    public static class GeoLocations
    {
        public static List<ProviderWrapper> GetProviderDistances(IEnumerable<ProviderResult> providers, double latitude, double longitude, int? maxDistance)
        {
            List<ProviderWrapper> distances = new List<ProviderWrapper>();
            foreach (var provider in providers)
            {
                var address = provider.Addresses.FirstOrDefault(t => t.AddressType.Equals("Physical", StringComparison.OrdinalIgnoreCase) && t.Latitude.HasValue && t.Longitude.HasValue);

                if (address == null)
                    continue;

                ProviderWrapper distance = new ProviderWrapper
                {
                    Providers = provider,
                    Distance = 0
                };

                if (address.Latitude != null && address.Longitude != null)
                    distance.Distance = GetDistanceInMiles(latitude, longitude, address.Latitude.Value, address.Longitude.Value);
                distances.Add(distance);
            }
            if (maxDistance.HasValue)
                distances = distances.Where(x => x.Distance <= maxDistance).ToList();

            return distances.OrderBy(t => t.Distance).ToList();
        }

        private static double GetDistanceInMiles(double lat1, double lon1, double lat2, double lon2)
        {
            double theta = lon1 - lon2;
            double distance = Math.Sin(Deg2Rad(lat1)) * Math.Sin(Deg2Rad(lat2)) + Math.Cos(Deg2Rad(lat1)) * Math.Cos(Deg2Rad(lat2)) * Math.Cos(Deg2Rad(theta));
            distance = Math.Acos(distance);
            distance = Rad2Deg(distance);
            distance = distance * 60 * 1.1515;
            return distance;
        }

        private static double Deg2Rad(double deg)
        {
            return deg * Math.PI / 180.0;
        }

        private static double Rad2Deg(double rad)
        {
            return rad / Math.PI * 180.0;
        }

        public static bool IsValidLatLong(this string value, out LatLong res)
        {
            bool result = false;
            res = new LatLong();
            string[] parts = value.Split(',');
            if (parts.Length == 2)
            {
                try
                {
                    double lat = Convert.ToDouble(parts[0]);
                    double longi = Convert.ToDouble(parts[1]);
                    if (lat >= -90.0 && lat <= 90.0 && longi >= -180.0 && longi <= 180.0)
                    {
                        res.Latitude = lat;
                        res.Longitude = longi;
                        result = true;
                    }
                }
                catch
                {
                }
            }
            return result;
        }
    }
}

