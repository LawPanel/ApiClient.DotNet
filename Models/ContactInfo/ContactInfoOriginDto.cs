using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;

namespace LawPanel.ApiClient.Models.ContactInfo
{
    public class ContactInfoOriginDto : Dto, IIdentifiableDto
    {
        public string   Id          { get; set; }

        [Display(Name = "[[[Source code]]]")]
        public int      Code        { get; set; }

        [Display(Name = "[[[Source]]]")]
        public string   Name        { get; set; }

        [Display(Name = "[[[Source description]]]")]
        public string   Description { get; set; }
    }
}
