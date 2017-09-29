using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.SearchClass
{
    public class SearchClassDto : Dto, IIdentifiableDto
    {
        public string   Id              { get; set; }

        [Display(Name = "[[[Class number]]]"), Required(ErrorMessage = "[[[Class number is required]]]", AllowEmptyStrings = false)]
        public int      Number          { get; set; }

        [Display(Name = "[[[Class name]]]"), Required(ErrorMessage = "[[[Class name is required]]]", AllowEmptyStrings = false)]
        public string   Name            { get; set; }

        [Display(Name = "[[[Description]]]"), Required(ErrorMessage = "[[[Class description is required]]]", AllowEmptyStrings = false)]
        public string   Description     { get; set; }

        [Display(Name = "[[[Search classes]]]")]
        public string   SearchClasses   { get; set; }


    }
}
