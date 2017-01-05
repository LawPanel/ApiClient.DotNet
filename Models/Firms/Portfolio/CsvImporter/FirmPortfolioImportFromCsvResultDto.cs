using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.Firms.Portfolio.CsvImporter
{
    public class FirmPortfolioImportFromCsvResultDto
    {
        public string                                       ProcessTime         { get; set; }
        public int                                          TotalImportedLines  { get; set; }
        public int                                          TotalFailedLines    { get; set; }
        public List<FirmPortfolioImportLineResult>          LinesImportResults  { get; set; }

        public FirmPortfolioImportFromCsvResultDto()
        {
            LinesImportResults = new List<FirmPortfolioImportLineResult>();
        }

    }
}
