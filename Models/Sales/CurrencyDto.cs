using System.Collections.Generic;
using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;
using LawPanel.ApiClient.Models.Helpers;

namespace LawPanel.ApiClient.Models.Sales
{
    public class CurrencyDto : Dto, IIdentifiableDto
    {
        public string           Id          { get; set; }
        public string           Name        { get; set; }
        public string           NameShort   { get; set; }
        public string           Symbol      { get; set; }
        public List<CountryDto> Countries   { get; set; }
    }
}
