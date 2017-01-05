using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;

namespace LawPanel.ApiClient.Models.Firms
{
    public class FirmWidgetSettingsSearchDomainDto : Dto, IIdentifiableDto
    {
        public string Id    { get; set; }
        public string Value { get; set; }
    }
}
