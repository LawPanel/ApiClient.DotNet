using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Firms.Widgets.Sales
{
    public class FirmWidgetSaleUpdateDto : FirmWidgetSaleCreateDto, IIdentifiableDto
    {
        public string Id { get; set; }
    }
}