using System;
using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.BrandMonitoring
{
    public class BrandMonitoringResultDto : Dto, IIdentifiableDto
    {
        public string   Id              { get; set; }
        [Display(Name = "[[[Trade site]]]")]
        public string   TradeSite       { get; set; }

        [Display(Name = "[[[Search terms]]]")]
        public string   SearchTerms     { get; set; }

        [Display(Name = "[[[First seen]]]")]
        public DateTime FirstSeen       { get; set; }

        [Display(Name = "[[[Link to seller]]]")]
        public string   LinkToSeller    { get; set; }

        [Display(Name = "[[[Listing image URL]]]")]
        public string   ListingImageUrl { get; set; }

        [Display(Name = "[[[Location]]]")]
        public string   Location        { get; set; }

        [Display(Name = "[[[Quantity]]]")]
        public long     Quantity        { get; set; }

        [Display(Name = "[[[Price]]]")]
        public decimal  Price           { get; set; }

        [Display(Name = "[[[Currency]]]")]
        public string   Currency        { get; set; }

        [Display(Name = "[[[Seller name]]]")]
        public string   SellerName      { get; set; }

        [Display(Name = "[[[Item number]]]")]
        public string   ItemNumber      { get; set; }

        [Display(Name = "[[[Listing snapshot]]]")]
        public string   ListingSnapshot { get; set; }

        [Display(Name = "[[[Description]]]")]
        public string   Description     { get; set; }

        public string Message { get; set; }
        
    }
}
