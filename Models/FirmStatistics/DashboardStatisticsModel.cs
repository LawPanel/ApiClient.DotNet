using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.FirmStatistics
{
    public class DashboardStatisticsModel
    {
        public List<SearchesByDate>             LastMonthSearches               { get; set; }
        public List<ClassNumbersRequested>      LastMonthClassNumbersRequested  { get; set; }
        public List<KeyValuePair<string, int>>  LastMonthSearchesSources        { get; set; }
        public List<KeyValuePair<long, int>>    LastMonthClientsLeads           { get; set; }

        public DashboardStatisticsModel()
        {
            LastMonthSearches = new List<SearchesByDate>();
            LastMonthClassNumbersRequested = new List<ClassNumbersRequested>();
            LastMonthSearchesSources = new List<KeyValuePair<string, int>>();
            LastMonthClientsLeads = new List<KeyValuePair<long, int>>();
        }
    }
}
