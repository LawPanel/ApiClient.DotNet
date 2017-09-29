using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Helpers
{
    public class LanguageDto : Dto, IIdentifiableDto
    {
        public string   Id                  { get; set; }
        [Display(Name = "[[[Language name]]]"), Required(ErrorMessage = "[[[Language name is required]]]", AllowEmptyStrings = false)]
        public string   Name                { get; set; }
        [Display(Name = "[[[Language short name]]]"), Required(ErrorMessage = "[[[Language short name is required]]]", AllowEmptyStrings = false)]
        public string   ShortName           { get; set; }
        public bool     IsAvailableForUi    { get; set; }
    }
}
