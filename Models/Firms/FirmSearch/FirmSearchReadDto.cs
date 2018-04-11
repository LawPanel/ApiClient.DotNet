using LawPanel.ApiClient.Attributes;
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

        [ApiExportable(0)]
        public SearchDto        Search          { get; set; }

        [ApiExportable(1)]
        public RegistryDto      Registry        { get; set; }

        [ApiExportable(2)]
        public SearchOriginDto  SearchOrigin    { get; set; }
    }
}