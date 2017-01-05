using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;

namespace LawPanel.ApiClient.Models.Sales
{
    public class ProductModifierDefinitionDto : Dto, IIdentifiableDto
    {
        public string                   Id                      { get; set; }
        public string                   Name                    { get; set; }
        public int                      Order                   { get; set; }
        public ProductModifierGroupDto  ProductModifierGroup    { get; set; }
    }
}