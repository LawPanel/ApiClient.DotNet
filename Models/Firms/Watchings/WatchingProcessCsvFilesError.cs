namespace LawPanel.ApiClient.Models.Firms.Watchings
{
    public class WatchingProcessCsvFilesError
    {
        public string   CompressedFileName  { get; set; }
        public string   CsvFileName         { get; set; }
        public int      LineNumber          { get; set; }
        public string   Message             { get; set; }
    }
}
