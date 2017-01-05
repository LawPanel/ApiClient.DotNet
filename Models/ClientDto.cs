using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;

namespace LawPanel.ApiClient.Models
{
    public class ClientDto : Dto, IIdentifiableDto
    {
        public string Id    { get; set; }

        [Display(Name = "[[[Client name]]]"), Required(ErrorMessage = "[[[Client name is required]]]", AllowEmptyStrings = false)]
        public string Name  { get; set; }
    }
}