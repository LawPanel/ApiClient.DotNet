using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.ContactInfo
{
    public class ContactInfoDto : Dto, IIdentifiableDto
    {
        public string                       Id                      { get; set; }

        [Display(Name = "[[[Type]]]")]
        public ContactInfoDefinitionDto     ContactInfoDefinition   { get; set; }

        public List<ContactInfoDetailDto>   ContactInfoDetails      { get; set; }

        public ContactInfoDto()
        {
            ContactInfoDetails = new List<ContactInfoDetailDto>();
        }


        public override string ToString()
        {
            if (ContactInfoDetails==null) return string.Empty;
            var result = ContactInfoDetails.Aggregate(string.Empty, (current, contactInfoDetailDto) => current + $"{contactInfoDetailDto.ContactInfoComponentDefinition.Description}: {contactInfoDetailDto.Value} / ");
            if (result != string.Empty) result = result.Substring(0, result.Length - 3);

            return result;
        }
    }
}
