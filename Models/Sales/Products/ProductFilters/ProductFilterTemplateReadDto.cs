using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Sales.Products.ProductFilters
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
