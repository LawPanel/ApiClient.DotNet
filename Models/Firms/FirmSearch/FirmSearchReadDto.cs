using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Registry;
using LawPanel.ApiClient.Models.Searches;
using LawPanel.ApiClient.Models.SearchOrigins;

namespace LawPanel.ApiClient.Models.Firms.FirmSearch
{
    public class FirmSearchReadDto : Dto, IIdentifiableDto
    {
        public string           Id              { get; set; }
        public FirmDto          Firm            { get; set; }
        public SearchDto        Search          { get; set; }
        public RegistryDto      Registry        { get; set; }
        public SearchOriginDto  SearchOrigin    { get; set; }
    }
}