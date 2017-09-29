using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Searches;
using LawPanel.ApiClient.Models.SearchOrigins;

namespace LawPanel.ApiClient.Models.Firms.FirmSearch
{
    public class FirmSearchDto : Dto, IIdentifiableDto
    {
        public string           Id                  { get; set; }
        public FirmDto          Firm                { get; set; }
        public SearchDto        Search              { get; set; }
        public SearchOriginDto  SearchOrigin        { get; set; }
    }
}
