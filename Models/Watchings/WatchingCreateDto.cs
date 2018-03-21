using System.ComponentModel.DataAnnotations;

namespace LawPanel.ApiClient.Models.Watchings
{
    public class WatchingCreateDto : Dto
    {
        [Display(Name = "[[[User]]]"), Required(ErrorMessage = "[[[User is required]]]", AllowEmptyStrings = false)]
        public string UserId { get; set; }

        [Display(Name = "[[[Registry]]]"), Required(ErrorMessage = "[[[Registry is required]]]", AllowEmptyStrings = false)]
        public string RegistryId { get; set; }

        [Display(Name = "[[[Frequency]]]"), Required(ErrorMessage = "[[[Frequency is required]]]", AllowEmptyStrings = false)]
        public string FrequencyId { get; set; }

        [Display(Name = "[[[Sensitivity]]]"), Required(ErrorMessage = "[[[Sensitivity is required]]]", AllowEmptyStrings = false)]
        public int Sensitivity { get; set; }

        [Display(Name = "[[[Application number]]]"), Required(ErrorMessage = "[[[Application number is required]]]", AllowEmptyStrings = false)]
        public string ApplicationNumber { get; set; }

        [Display(Name = "[[[Trademark]]]"), Required(ErrorMessage = "[[[Trademark is required]]]", AllowEmptyStrings = false)]
        public string Trademark { get; set; }

        [Display(Name = "[[[Classes]]]"), Required(ErrorMessage = "[[[To create a watching you need to specify the classes numbers]]]", AllowEmptyStrings = false)]
        public string Classes { get; set; }

        [Display(Name = "[[[Owner]]]"), Required(ErrorMessage = "[[[Owner is required]]]", AllowEmptyStrings = true)]
        public string Owner { get; set; }

        [Display(Name = "[[[Firm portfolio]]]")]
        public string FirmPortfolioId { get; set; }
    }
}