using System.Collections.Generic;
using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;

namespace LawPanel.ApiClient.Models.Sales 
{
    public class ProductDto : Dto, IIdentifiableDto
    {
        public string                       Id                      { get; set; }
        public int                          Code                    { get; set; }
        public string                       Name                    { get; set; }
        public string                       NamePublic              { get; set; }
        public ProductTypeDto               ProductType             { get; set; }
        public List<PriceDto>               Prices                  { get; set; }
        public List<ProductModifierDto>     ProductModifiers        { get; set; }
        public List<TaxDto>                 Taxes                   { get; set; }
    }
}