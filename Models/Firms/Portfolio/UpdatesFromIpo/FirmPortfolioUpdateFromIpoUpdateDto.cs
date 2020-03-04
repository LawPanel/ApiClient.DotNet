using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Firms.Portfolio.UpdatesFromIpo
{
    public class FirmPortfolioUpdateFromIpoUpdateDto : Dto, IIdentifiableDto
    {
        public string Id            { get; set; }
        public string Observations  { get; set; }
    }
}