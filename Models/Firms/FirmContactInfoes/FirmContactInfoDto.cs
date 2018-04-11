using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Attributes;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.ContactInfo;

namespace LawPanel.ApiClient.Models.Firms.FirmContactInfoes
{
    public class FirmContactInfoDto : Dto, IIdentifiableDto
    {
        public string                       Id                          { get; set; }

        [Display(Name = "[[[Contact]]]")]
        [ApiExportable(3)]
        public ContactInfoDto               ContactInfo                 { get; set; }

        [Display(Name = "[[[Origin]]]")]
        [ApiExportable(2)]
        public ContactInfoOriginDto         ContactInfoOrigin           { get; set; }

        [ApiExportable(0)]
        [Display(Name = "[[[Status]]]")]
        public FirmContactInfoStatusDto     FirmContactInfoStatus       { get; set; }

        [ApiExportable(1)]
        [Display(Name = "[[[Quality]]]")]
        public FirmContactInfoQualityDto    FirmContactInfoQuality      { get; set; }

        
        [Display(Name = "[[[Details on source]]]")]
        public string                       ContactInfoOriginDetails    { get; set; }
        
        public FirmDto                      Firm                        { get; set; }
    }
}