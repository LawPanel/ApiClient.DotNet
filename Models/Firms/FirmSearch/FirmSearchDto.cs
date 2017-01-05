using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;
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
