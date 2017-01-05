using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;

namespace LawPanel.ApiClient.Models.Sales
{
    public class ProductFilterTemplateReadDto : Dto, IIdentifiableDto
    {
        public string   Id                      { get; set; }
        public string   Name                    { get; set; }
        public int      ProductModifierGroups   { get; set; }

        public ProductFilterTemplateReadDto()
        {
        }
    }
}
