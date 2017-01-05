using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.FirmStatistics
{
    public class SearchesByDate
    {
        public long                                 Date                    { get; set; }
        public int                                  Searches                { get; set; }
        public List<KeyValuePair<string, int>>      SearchesByRegistries    { get; set; }
        public List<KeyValuePair<string, int>>      SearchesByClasses       { get; set; }


        public SearchesByDate()
        {
            SearchesByRegistries = new List<KeyValuePair<string, int>>();
            SearchesByClasses = new List<KeyValuePair<string, int>>();
        }
    }
}
