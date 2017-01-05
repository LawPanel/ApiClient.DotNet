using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;

namespace LawPanel.ApiClient.Models.Helpers
{
    public class LanguageDto : Dto, IIdentifiableDto
    {
        public string Id        { get; set; }

        [Display(Name = "[[[Language name]]]"), Required(ErrorMessage = "[[[Language name is required]]]", AllowEmptyStrings = false)]
        public string Name      { get; set; }

        [Display(Name = "[[[Language short name]]]"), Required(ErrorMessage = "[[[Language short name is required]]]", AllowEmptyStrings = false)]
        public string ShortName { get; set; }

    }
}
