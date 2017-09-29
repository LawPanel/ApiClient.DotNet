using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Sales;
using LawPanel.ApiClient.Models.Sales.Products;
using LawPanel.ApiClient.Models.Sales.Products.ProductFilters;

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