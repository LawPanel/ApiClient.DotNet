using System;
using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;

namespace LawPanel.ApiClient.Models.Sales
{
    public class PriceDto : Dto, IIdentifiableDto
    {
        public string       Id              { get; set; }
        public DateTime     DateTime        { get; set; }
        public CurrencyDto  Currency        { get; set; }
        public decimal      CurrencyUnits   { get; set; }
    }
}