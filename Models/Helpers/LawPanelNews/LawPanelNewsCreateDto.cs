using System;
using System.ComponentModel.DataAnnotations;

namespace LawPanel.ApiClient.Models.Helpers.LawPanelNews
{
    public class LawPanelNewsCreateDto : Dto
    {
        [Display(Name = "[[[Type]]]")]
        [Required(ErrorMessage = "[[[News type is required]]]")]
        public Guid     LawPanelNewsTypeId  { get; set; }
        
        [Display(Name = "[[[Title]]]")]
        [Required(ErrorMessage = "[[[Title is required]]]")]
        public string   Title               { get; set; } 

        [Required(ErrorMessage = "[[[Sub-title is required]]]")]
        [Display(Name = "[[[Summary]]]")]
        public string   SubTitle            { get; set; }

        [Display(Name = "[[[Thumbnail]]]")]
        public string   ThumbnailUrl        { get; set; }

        [Display(Name = "[[[Contents]]]")]
        [Required(ErrorMessage = "[[[Content is required]]]")]
        public string   Contents            { get; set; }
    }
}