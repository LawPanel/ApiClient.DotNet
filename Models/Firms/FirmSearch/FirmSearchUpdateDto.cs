using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Firms.FirmSearch
{
    public class FirmSearchUpdateDto : Dto, IIdentifiableDto
    {
        public string   Id          { get; set; }
        public string   SearchId    { get; set; }
    }
}
