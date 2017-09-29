using System.ComponentModel.DataAnnotations;

namespace LawPanel.ApiClient.Models.Tags
{
    public class TagCreateDto : Dto
    {
        [Display(Name = "[[[Tag name]]]"), Required(AllowEmptyStrings = false)]
        public string   Name            { get; set; }
        [Display(Name = "[[[Text color]]]"), Required(AllowEmptyStrings = false)]
        public string   ColorText       { get; set; }
        [Display(Name = "[[[Background color]]]"), Required(AllowEmptyStrings = false)]
        public string   ColorBackground { get; set; }
        [Display(Name = "[[[Parent]]]")]
        public string   ParentId        { get; set; }

        public TagCreateDto()
        {
            ColorText = "#02404c";
            ColorBackground = "#e2ebed";
        }
    }
}