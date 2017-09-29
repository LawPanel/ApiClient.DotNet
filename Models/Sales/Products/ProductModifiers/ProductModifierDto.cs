using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Sales.Products.ProductModifiers
{
    public class ProductModifierDto : Dto, IIdentifiableDto
    {
        public string                       Id                          { get; set; }
        public ProductModifierDefinitionDto ProductModifierDefinition   { get; set; }
        public ProductDto                   Product                     { get; set; }
        public List<ProductModifierDto>     ProductModifiersCombined    { get; set; } // If exist, the price modifier should be applied only in presence of that PriceModifers
        public decimal                      Units                       { get; set; }
        public decimal                      Percent                     { get; set; }
    }
}