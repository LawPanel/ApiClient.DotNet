using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Sales.Products;

namespace LawPanel.ApiClient.Models.Firms.Sales.FirmProducts
{
    public class FirmProductDto : Dto, IIdentifiableDto
    {
        public string       Id      { get; set; }
        public FirmDto      Firm    { get; set; }
        public ProductDto   Product { get; set; }

        public FirmProductDto()
        {
            Product = new ProductDto();
        }
    }
}