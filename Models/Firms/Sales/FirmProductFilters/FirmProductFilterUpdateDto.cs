using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Firms.Sales.FirmProductFilters
{
    public class FirmProductFilterUpdateDto : FirmProductFilterCreateDto, IIdentifiableDto
    {
        public string   Id              { get; set; }
    }
}