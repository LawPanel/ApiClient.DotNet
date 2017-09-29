using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.ContactInfo
{
    public class ContactInfoComponentDefinitionDto : Dto, IIdentifiableDto
    {
        public string   Id                          { get; set; }
        [Display(Name = "[[[Component name]]]"), Required(ErrorMessage = "[[[Component name is required]]]", AllowEmptyStrings = false)]
        public string   Name                        { get; set; }
        [Display(Name = "[[[Component description]]]"), Required(ErrorMessage = "[[[Component description is required]]]", AllowEmptyStrings = false)]
        public string   Description                 { get; set; }

        [Display(Name = "[[[CSS class name]]]")]
        public string   ClassName                   { get; set; }

        [Display(Name = "[[[Regular expression to validate]]]")]
        public string   RegularExpressionToValidate { get; set; }

        [Display(Name = "[[[This field is required?]]]")]
        public bool     IsRequired                  { get; set; }
    }
}
