using System;
using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.FirmStatistics
{
    public class LeadsByDate
    {
        public DateTime                         Date                { get; set; }
        public long                             DateAsUnixTimeStamp { get; set; }
        public int                              Leads               { get; set; }
        public List<KeyValuePair<string, int>>  LeadsByOrigin       { get; set; }

        public LeadsByDate()
        {
            LeadsByOrigin = new List<KeyValuePair<string, int>>();
        }
    }
}