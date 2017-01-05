using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;
using LawPanel.ApiClient.Constants;

namespace LawPanel.ApiClient.Models.Firms
{
    public class FirmUiSettingsDto : Dto, IIdentifiableDto
    {
        public string Id            { get; set; }

        [Display(Name = "[[[Firm header logo URL]]]"), Required(ErrorMessage = "[[[Firm header logo URL is required]]]", AllowEmptyStrings = false)]
        [RegularExpression(RegexConsts.SecureImageUrl, ErrorMessage = "[[[Not a valid image URL. Must start with \"https\" and be a image]]]")]
        public string HeaderLogoUrl { get; set; }

        [Display(Name = "[[[Firm logo URL]]]"), Required(ErrorMessage = "[[[Firm logo URL is required]]]", AllowEmptyStrings = false)]
        [RegularExpression(RegexConsts.SecureImageUrl, ErrorMessage = "[[[Not a valid image URL, must start with \"https\"]]]")]
        public string SecondaryLogoUrl { get; set; }

        [Display(Name = "[[[Header color left]]]"), Required(ErrorMessage = "[[[Header color left is required]]]", AllowEmptyStrings = false)]
        [RegularExpression(RegexConsts.HtmlColor, ErrorMessage = "[[[Not a valid HTML color]]]")]
        public string HeaderColorLeft { get; set; }

        [Display(Name = "[[[Header color right]]]"), Required(ErrorMessage = "[[[Header color right is required]]]", AllowEmptyStrings = false)]
        [RegularExpression(RegexConsts.HtmlColor, ErrorMessage = "[[[Not a valid HTML color]]]")]
        public string HeaderColorRight { get; set; }
    }
}
