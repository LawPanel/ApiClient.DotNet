using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Sales.Products
{
    public class ProductTypeDto : Dto, IIdentifiableDto
    {
        public string Id    { get; set; }
        public string Name  { get; set; }
    }
}