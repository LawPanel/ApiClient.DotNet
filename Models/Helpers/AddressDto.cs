using System;
using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Helpers
{
    public class AddressDto : Dto, IIdentifiableDto
    {
        public string   Id              { get; set; }

        [Display(Name = "[[[Line 1]]]")]
        public string   Line1           { get; set; }

        [Display(Name = "[[[Line 2]]]")]
        public string   Line2           { get; set; }

        [Display(Name = "[[[Line 3]]]")]
        public string   Line3           { get; set; }

        [Display(Name = "[[[Building]]]")]
        public string   Building        { get; set; }

        [Display(Name = "[[[Floor level]]]")]
        public string   FloorLevel      { get; set; }

        [Display(Name = "[[[Zip / Postal code]]]")]
        public string   PostalCode      { get; set; }

        [Display(Name = "[[[City]]]")]
        public string   City            { get; set; }

        [Display(Name = "[[[State / Province]]]")]
        public string   StateProvince   { get; set; }

        [Display(Name = "[[[Region]]]")]
        public string   Region          { get; set; }

        [Display(Name = "[[[Country]]]")]
        public Guid     CountryId       { get; set; }
        public string   CountryName     { get; set; }

    }
}