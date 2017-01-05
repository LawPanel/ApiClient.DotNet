using System.Collections.Generic;
using LawPanel.ApiClient.Abstractions.Interfaces;

namespace LawPanel.ApiClient.Models.Sales
{
    public class ProductFilterDetailDto : IIdentifiableDto
    {
        public string                               Id                          { get; set; }
        public ProductFilterDto                     ProductFilter               { get; set; }
        public List<ProductDto>                     Products                    { get; set; } // These products
        public List<ProductModifierDefinitionDto>   ProductModifierDefinitions  { get; set; } // i.e.: UK, EUIPO - 1,2,3,4,5,6,7,8
    }
}
