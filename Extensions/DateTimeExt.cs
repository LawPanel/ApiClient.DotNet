using System;

namespace LawPanel.ApiClient.Extensions
{
    public static class DateTimeExt
    {
        private static readonly DateTime UnixTimeStamp = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);


        public static long DateTimeToUnixTimeStamp(this DateTime dateTime, bool convertToUtc = true)
        {
            if (!convertToUtc) return (long) (dateTime - UnixTimeStamp).TotalSeconds;

            // Convet date time to UTC
            var dateTimeUtc = TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.Utc);

            return (long)(dateTimeUtc - UnixTimeStamp).TotalSeconds;
        }

        public static DateTime UnixTimeStampToDateTime(this double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
