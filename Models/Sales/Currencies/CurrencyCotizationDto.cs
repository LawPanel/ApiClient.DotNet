using System;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Sales.Currencies
{
    public class CurrencyCotizationDto : Dto, IIdentifiableDto
    {
        public string       Id                  { get; set; }
        public CurrencyDto  Currency            { get; set; }
        public CurrencyDto  CurrencyReference   { get; set; }
        public decimal      CurrencyRelation    { get; set; }
        public DateTime     From                { get; set; }
    }
}