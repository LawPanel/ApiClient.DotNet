using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Watchings
{
    public class WatchingUserSettingsDto : Dto, IIdentifiableDto
    {
        public string   Id              { get; set; }

        [Display(Name = "[[[User]]]"), Required(ErrorMessage = "[[[User is required]]]", AllowEmptyStrings = false)]
        public string   UserId          { get; set; }
        public string   UserName        { get; set; }


        [Display(Name = "[[[Frequency]]]"), Required(ErrorMessage = "[[[Frequency is required]]]", AllowEmptyStrings = false)]
        public string   FrequencyId     { get; set; }
        public string   FrequencyName   { get; set; }


        [Display(Name = "[[[Sensitivity]]]"), Required(ErrorMessage = "[[[Sensitivity is required]]]", AllowEmptyStrings = false)]
        public int      Sensitivity     { get; set; }
    }
}
