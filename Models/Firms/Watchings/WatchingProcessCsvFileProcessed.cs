using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.Firms.Watchings
{
    public class WatchingProcessCsvFileProcessed
    {
        public string       CompressedFileName  { get; set; }
        public string       CsvFileName         { get; set; }
        public List<string> Messages            { get; set; }
        public int          LinesProcessed      { get; set; }

        public WatchingProcessCsvFileProcessed ()
        {
            Messages = new List<string>();
        }
    }
}
