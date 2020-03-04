using System;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Firms.Portfolio.UpdatesFromIpo
{
    public class FirmPortfolioUpdateFromIpoResultDto : IIdentifiableDto
    {
        public string       Id              { get; set; }
        public string       PropertyName    { get; set; }
        public string       OriginalValue   { get; set; }
        public string       UpdatedValue    { get; set; }
        public string       ExtraDetails    { get; set; }
        public DateTime?    AppliedAt       { get; set; }
    }
}
