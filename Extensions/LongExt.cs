using System;

namespace LawPanel.ApiClient.Extensions
{
    public static class LongExt
    {
        public static DateTime ToUtcDateFromEpoch(this long seconds)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(seconds);
        }

        public static DateTime ToDateFromEpoch(this long seconds)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return epoch.AddSeconds(seconds).ToLocalTime();
        }
    }
}
