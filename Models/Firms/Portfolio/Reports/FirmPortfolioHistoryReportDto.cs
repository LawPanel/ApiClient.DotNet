using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.Firms.Portfolio.Reports
{
    public class FirmPortfolioHistoryReportDto
    {
        public FirmPortfolioReadDto                         FirmPortfolioRead   { get; set; }
        public List<FirmPortfolioHistoryReportDetailDto>    Details             { get; set; }

        public FirmPortfolioHistoryReportDto()
        {
            Details = new List<FirmPortfolioHistoryReportDetailDto>();
        }
    }
}
