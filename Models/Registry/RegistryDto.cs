using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;

namespace LawPanel.ApiClient.Models.Registry
{
    public class RegistryDto : Dto , IIdentifiableDto
    {
        public string   Id                      { get; set; }

        [Display(Name = "[[[Registry name]]]"), Required(ErrorMessage = "[[[Registry name is required]]]", AllowEmptyStrings = false)]
        public string   Name                    { get; set; }

        [Display(Name = "[[[Description]]]")]
        public string   Description             { get; set; }

        [Display(Name = "[[[Registry internal code]]]"), Required(ErrorMessage = "[[[Registry code is required]]]")]
        public int      Code                    { get; set; }

        [Display(Name = "[[[URL base to show trademarks]]]")]
        public string   UrlBaseForTrademarks    { get; set; }

        public int      TrademarkRegistry       { get; set; }

        // https://blackfish.teamworkpm.net/tasks/4423606
        // Prefiero hacerlo así porque no se que puede pasar si lo cambio en la BBDD gracias a los enums
        public string NameInUpperCase => Name.ToUpperInvariant();
    }
}