using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.ContactInfo;

namespace LawPanel.ApiClient.Models.Firms.FirmContactInfoes
{
    public class FirmContactInfoUpdateDto : Dto, IIdentifiableDto
    {
        public string                       Id                          { get; set; }
        public ContactInfoDto               ContactInfo                 { get; set; }
        public ContactInfoOriginDto         ContactInfoOrigin           { get; set; }
        public FirmContactInfoStatusDto     FirmContactInfoStatus       { get; set; }
        public FirmContactInfoQualityDto    FirmContactInfoQuality      { get; set; }

        [Display(Name = "[[[Details on source]]]")]
        public string                   ContactInfoOriginDetails    { get; set; }
        
        public FirmDto                  Firm                        { get; set; }
    }
}