using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Sales.Products.ProductModifiers;

namespace LawPanel.ApiClient.Models.Sales.Products 
{
    public class ProductDto : Dto, IIdentifiableDto
    {
        public string                       Id                      { get; set; }
        public string                       Code                    { get; set; }
        public string                       Name                    { get; set; }
        public string                       NamePublic              { get; set; }
        public ProductTypeDto               ProductType             { get; set; }
        public List<PriceDto>               Prices                  { get; set; }
        public List<ProductModifierDto>     ProductModifiers        { get; set; }
        public List<TaxDto>                 Taxes                   { get; set; }
    }
}