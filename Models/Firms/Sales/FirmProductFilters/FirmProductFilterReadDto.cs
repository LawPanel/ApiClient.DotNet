using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Firms.Sales.FirmProductFilters
{
    public class FirmProductFilterReadDto : Dto, IIdentifiableDto
    {
        public string   Id              { get; set; }
        public string   Name            { get; set; }
        public int      Categories      { get; set; }
        public int      Products        { get; set; }
    }
}