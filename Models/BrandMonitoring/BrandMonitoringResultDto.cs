using System;
using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;

namespace LawPanel.ApiClient.Models.BrandMonitoring
{
    public class BrandMonitoringResultDto : Dto, IIdentifiableDto
    {
        public string   Id              { get; set; }
        public string   TradeSite       { get; set; }
        public string   SearchTerms     { get; set; }
        public DateTime FirstSeen       { get; set; }
        public string   LinkToSeller    { get; set; }
        public string   ListingImageUrl { get; set; }
        public string   Location        { get; set; }
        public long     Quantity        { get; set; }
        public decimal  Price           { get; set; }
        public string   Currency        { get; set; }
        public string   SellerName      { get; set; }
        public string   ItemNumber      { get; set; }
        public string   ListingSnapshot { get; set; }
        public string   Description     { get; set; }
        
    }
}
