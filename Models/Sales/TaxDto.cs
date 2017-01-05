using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;

namespace LawPanel.ApiClient.Models.Sales
{
    public class TaxDto : Dto, IIdentifiableDto
    {
        public string   Id          { get; set; }
        public string   Name        { get; set; }
        public string   Description { get; set; }
        public decimal  Units       { get; set; }
        public decimal  Percent     { get; set; }
    }
}