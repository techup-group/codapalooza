using System;

namespace TampaInnovation.Business.Helpers
{
    public class Utilities
    {
        public static double CurrentUnixTimeStamp(DateTime dateTime)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dateTime.Subtract(epoch).TotalSeconds;
        }
    }
}
