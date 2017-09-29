using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.ContactInfo
{
    public class ContactInfoDefinitionDto : Dto, IIdentifiableDto
    {
        public string                                   Id                      { get; set; }
        [Display(Name = "[[[Contact info name]]]"), Required(ErrorMessage = "[[[Contact info name is required]]]", AllowEmptyStrings = false)]
        public string                                   Name                    { get; set; }

        [Display(Name = "[[[Components of contact]]]")]
        public IList<ContactInfoComponentDefinitionDto> ComponentsDefinitions   { get; set; }

        public bool                                     ShowOnSearchWidget      { get; set; }
    }
}
