
using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Firms.Portfolio.UpdatesFromIpo
{
    public class FirmPortfolioUpdateFromIpoDetailDto : Dto, IIdentifiableDto
    {
        public string                                           Id              { get; set; }
        public FlatFirmPortfolioDto                             FirmPortfolio   { get; set; }
        public IEnumerable<FirmPortfolioUpdateFromIpoResultDto> Results         { get; set; }
        public string                                           ResultMessage   { get; set; }
        public bool                                             Excluded        { get; set; }
        
        public FirmPortfolioUpdateFromIpoDetailDto()
        {
            Results = new List<FirmPortfolioUpdateFromIpoResultDto>();
        }
    }

    #region Flattened DTOs

    #region FirmPortfolioDto
    public class FlatFirmPortfolioDto 
    {
        public Guid             Id                  { get; set; }
        public string           ApplicationNumber   { get; set; }
        public DateTime?        ApplicationDate     { get; set; }
        public DateTime?        RegistrationDate    { get; set; }
        public DateTime?        ExpiryDate          { get; set; }
        public string           MarkText            { get; set; }
        public FlatRegistryDto  Registry            { get; set; }
        public string           MarkOwner           { get; set; }
        public IEnumerable<int> Classes             { get; set; }

        public FlatFirmPortfolioDto()
        {
            Classes = new List<int>();
        }
    }
    #endregion

    #region RegistryDto
    public class FlatRegistryDto 
    {
        public Guid     Id                      { get; set; }
        public string   Name                    { get; set; }
        public string   Description             { get; set; }
        public string   OfficialName            { get; set; }
        public string   WipoCode                { get; set; }
        public string   UrlBaseForTrademarks    { get; set; }
        public int      TrademarkRegistry       { get; set; }
    }
    #endregion

    #endregion
}