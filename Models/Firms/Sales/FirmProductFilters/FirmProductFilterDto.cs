using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Sales;
using LawPanel.ApiClient.Models.Sales.Products.ProductFilters;

namespace LawPanel.ApiClient.Models.Firms.Sales.FirmProductFilters
{
    public class FirmProductFilterDto : Dto, IIdentifiableDto
    {
        public string                   Id                      { get; set; }
        public FirmDto                  Firm                    { get; set; }
        public ProductFilterDto         ProductFilter           { get; set; }
        public ProductFilterTemplateDto ProductFilterTemplate   { get; set; }
    }
}