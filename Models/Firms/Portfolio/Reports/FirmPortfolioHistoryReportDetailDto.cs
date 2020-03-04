using System;
using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.Firms.Portfolio.Reports
{
    public class FirmPortfolioHistoryReportDetailDto
    {
        public DateTime                                             DateTime                { get; set; }
        public FirmPortfolioHistoryDto                              FirmPortfolioHistory    { get; set; }
        public string                                               Differences             { get; set; }
        public List<FirmPortfolioHistoryReportDetailPropertyDto>    PropertiesChanged       { get; set; }

        public FirmPortfolioHistoryReportDetailDto()
        {
            PropertiesChanged = new List<FirmPortfolioHistoryReportDetailPropertyDto>();
        }
    }
}
