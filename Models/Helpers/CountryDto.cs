using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;

namespace LawPanel.ApiClient.Models.Helpers
{
    public class CountryDto : Dto, IIdentifiableDto
    {
        public string Id        { get; set; }

        [Display(Name = "[[[Country name]]]"), Required(ErrorMessage = "[[[Country name is required]]]", AllowEmptyStrings = false)]
        public string Name      { get; set; }

        [Display(Name = "[[[Country short name]]]"), Required(ErrorMessage = "[[[Country short name is required]]]", AllowEmptyStrings = false)]
        public string ShortName { get; set; }
     
    }
}
