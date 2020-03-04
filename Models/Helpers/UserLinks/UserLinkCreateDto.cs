using System.ComponentModel.DataAnnotations;

namespace LawPanel.ApiClient.Models.Helpers.UserLinks
{
    public class UserLinkCreateDto : Dto
    {
        [Required(ErrorMessage = "[[[Url content is required]]]")]
        public string   Url         { get; set; } 
        public string   Comments    { get; set; }
    }
}