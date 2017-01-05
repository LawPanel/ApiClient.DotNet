namespace LawPanel.ApiClient.Models.Firms.Portfolio.CsvImporter
{
    public class FirmPortfolioImportLineResult
    {
        public int      LineNumber  { get; set; }
        public string   Message     { get; set; }
        public bool     Successfull { get; set; }
    }
}
