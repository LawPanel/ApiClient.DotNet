using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Sales.Products.ProductModifiers
{
    public class ProductModifierGroupDto :  IIdentifiableDto
    {
        public string                               Id                          { get; set; }
        public string                               Name                        { get; set; }
        public int                                  Order                       { get; set; }
        public bool                                 Multiple                    { get; set; }
        public List<ProductModifierDefinitionDto>   ProductModifierDefinitions  { get; set; }


        public ProductModifierGroupDto()
        {
            ProductModifierDefinitions = new List<ProductModifierDefinitionDto>();
        }
    }
}