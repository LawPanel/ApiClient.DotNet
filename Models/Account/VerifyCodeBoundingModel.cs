using System.ComponentModel.DataAnnotations;

namespace LawPanel.ApiClient.Models.Account
{
    public class VerifyCodeBoundingModel
    {
        [Required(ErrorMessage = "[[[Code is required]]]", AllowEmptyStrings = false)]
        public string Code { get; set; }
    }
}
