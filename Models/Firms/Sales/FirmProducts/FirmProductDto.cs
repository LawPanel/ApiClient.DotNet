using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;
using LawPanel.ApiClient.Models.Sales;

namespace LawPanel.ApiClient.Models.Firms.Sales.FirmProducts
{
    public class FirmProductDto : Dto, IIdentifiableDto
    {
        public string       Id      { get; set; }
        public FirmDto      Firm    { get; set; }
        public ProductDto   Product { get; set; }
    }
}