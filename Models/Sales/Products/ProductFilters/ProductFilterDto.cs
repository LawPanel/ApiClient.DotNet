using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Sales.Products.ProductFilters
{
    public class ProductFilterDto : Dto, IIdentifiableDto
    {
        public string                       Id                      { get; set; }
        public string                       Name                    { get; set; }
        public string                       InternalName            { get; set; }
        public List<ProductFilterDetailDto> ProductFilterDetails    { get; set; }
    }
}
