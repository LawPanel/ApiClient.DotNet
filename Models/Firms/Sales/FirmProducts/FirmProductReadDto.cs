using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;

namespace LawPanel.ApiClient.Models.Firms.Sales.FirmProducts
{
    public class FirmProductReadDto : Dto, IIdentifiableDto
    {
        public string   Id              { get; set; }
        public int      Code            { get; set; }
        public string   Name            { get; set; }
        public string   NamePublic      { get; set; }
        public string   CurrencySymbol  { get; set; }
        public decimal  Value           { get; set; }
        public decimal  TaxPercent      { get; set; }
        public decimal  TaxValue        { get; set; }
    }
}