using System.Collections.Generic;
using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;
using LawPanel.ApiClient.Models.Sales;

namespace LawPanel.ApiClient.Models.Firms.Widgets.Sales
{
    public class FirmWidgetSaleDto : Dto, IIdentifiableDto
    {
        public string                       Id                      { get; set; }
        public string                       Name                    { get; set; }
        public List<ProductDto>             Products                { get; set; }
        public ProductFilterDto             ProductFilter           { get; set; }
        public FirmWidgetSalesSettingsDto   FirmWidgetSalesSettings { get; set; }

        public FirmWidgetSaleDto()
        {
            Products = new List<ProductDto>();
        }
    }
}