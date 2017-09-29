using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.ContactInfo;

namespace LawPanel.ApiClient.Models.Firms.FirmContactInfoes
{
    public class FirmContactInfoDto : Dto, IIdentifiableDto
    {
        public string                       Id                          { get; set; }

        public ContactInfoDto               ContactInfo                 { get; set; }

        [Display(Name = "[[[Origin]]]")]
        public ContactInfoOriginDto         ContactInfoOrigin           { get; set; }

        [Display(Name = "[[[Status]]]")]
        public FirmContactInfoStatusDto     FirmContactInfoStatus       { get; set; }

        [Display(Name = "[[[Quality]]]")]
        public FirmContactInfoQualityDto    FirmContactInfoQuality      { get; set; }

        [Display(Name = "[[[Details on source]]]")]
        public string                       ContactInfoOriginDetails    { get; set; }
        
        public FirmDto                      Firm                        { get; set; }
    }
}