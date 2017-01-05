using System.ComponentModel.DataAnnotations;

namespace LawPanel.ApiClient.Models.Account
{
    /// <summary>
    /// Login model, used for login.
    /// </summary>
    public class LoginBindingModel
    {
        [Required(ErrorMessage = "[[[Email is required]]]", AllowEmptyStrings = false)]
        public string   Email       { get; set; }

        [Required(ErrorMessage = "[[[Password is required]]]", AllowEmptyStrings = false)]
        public string   Password    { get; set; }
        public bool     RememberMe  { get; set; }
    }
}