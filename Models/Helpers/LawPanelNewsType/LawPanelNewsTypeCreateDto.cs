using System.ComponentModel.DataAnnotations;

namespace LawPanel.ApiClient.Models.Helpers.LawPanelNewsType
{
    public class LawPanelNewsTypeCreateDto : Dto
    {
        [Required(ErrorMessage = "[[[Code is required]]]")]
        public int Code { get; set; }

        [Required(ErrorMessage = "[[[Title is required]]]")]
        public string   Name               { get; set; } 
    }
}