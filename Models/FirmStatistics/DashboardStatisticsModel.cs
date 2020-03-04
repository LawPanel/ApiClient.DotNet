using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.FirmStatistics
{
    public class DashboardStatisticsModel
    {
        public List<string>                     LastMonthSearchesRegistries     { get; set; }
        public List<SearchesByDate>             LastMonthSearches               { get; set; }
        public List<ClassNumbersRequested>      LastMonthClassNumbersRequested  { get; set; }
        public List<KeyValuePair<string, int>>  LastMonthSearchesSources        { get; set; }
        public List<LeadsByDate>                LastMonthClientsLeads           { get; set; }
        public List<string>                     LastMonthClientsLeadsOrigin     { get; set; }
        public List<DetailsByRegistry>          DetailsByRegistries             { get; set; }

        public DashboardStatisticsModel()
        {
            LastMonthSearches = new List<SearchesByDate>();
            LastMonthClassNumbersRequested = new List<ClassNumbersRequested>();
            LastMonthSearchesSources = new List<KeyValuePair<string, int>>();
            LastMonthClientsLeads = new List<LeadsByDate>();
            LastMonthClientsLeadsOrigin = new List<string>();
            LastMonthSearchesRegistries = new List<string>();
            DetailsByRegistries = new List<DetailsByRegistry>();
        }
    }
}
