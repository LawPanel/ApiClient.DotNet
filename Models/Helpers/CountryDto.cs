using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Attributes;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Helpers
{
    public class CountryDto : Dto, IIdentifiableDto
    {
        public string Id        { get; set; }

        [Display(Name = "[[[Country name]]]"), Required(ErrorMessage = "[[[Country name is required]]]", AllowEmptyStrings = false)]
        [DefaultOrder(1, OrderDirection.Asc)]
        public string Name      { get; set; }

        [Display(Name = "[[[Country short name]]]"), Required(ErrorMessage = "[[[Country short name is required]]]", AllowEmptyStrings = false)]
        public string ShortName { get; set; }

        [Display(Name = "[[[Weight order]]]")]
        [DefaultOrder(0, OrderDirection.Desc)]
        public int WeightOrder { get; set; }

    }
}
