using System.ComponentModel.DataAnnotations;

namespace LawPanel.ApiClient.Models.Watchings
{
    public class WatchingCreateDto : Dto
    {
        [Display(Name = "[[[User]]]"), Required(ErrorMessage = "[[[User is required]]]", AllowEmptyStrings = false)]
        public string UserId { get; set; }

        [Display(Name = "[[[Frequency]]]"), Required(ErrorMessage = "[[[Frequency is required]]]", AllowEmptyStrings = false)]
        public string FrequencyId { get; set; }

        [Display(Name = "[[[Sensitivity]]]"), Required(ErrorMessage = "[[[Sensitivity is required]]]", AllowEmptyStrings = false)]
        public int Sensitivity { get; set; }

        [Display(Name = "[[[Firm portfolio]]]")]
        public string FirmPortfolioId { get; set; }
    }
}