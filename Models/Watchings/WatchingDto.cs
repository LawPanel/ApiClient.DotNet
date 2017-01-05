using System;
using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;

namespace LawPanel.ApiClient.Models.Watchings
{
    public class WatchingDto : Dto, IIdentifiableDto
    {
        public string       Id                  { get; set; }

        [Display(Name = "[[[Firm]]]"), Required(ErrorMessage = "[[[Firm is required]]]", AllowEmptyStrings = false)]
        public string       FirmId              { get; set; }
        public string       FirmName            { get; set; }

        public DateTime     Created             { get; set; }

        [Display(Name = "[[[User]]]"), Required(ErrorMessage = "[[[User is required]]]", AllowEmptyStrings = false)]
        public string       UserId              { get; set; }
        public string       UserName            { get; set; }


        [Display(Name = "[[[Sensitivity]]]"), Required(ErrorMessage = "[[[Sensitivity is required]]]", AllowEmptyStrings = false)]
        public int          Sensitivity         { get; set; }


        [Display(Name = "[[[Application number]]]"), Required(ErrorMessage = "[[[Application number is required]]]", AllowEmptyStrings = false)]
        public string       ApplicationNumber   { get; set; }


        [Display(Name = "[[[Trademark]]]"), Required(ErrorMessage = "[[[Trademark is required]]]", AllowEmptyStrings = false)]
        public string       Trademark           { get; set; }


        public DateTime?    LastSearchDate      { get; set; }


        public int?         LastSearchResults   { get; set; }


        [Display(Name = "[[[Classes]]]"), Required(ErrorMessage = "[[[Classes is required]]]", AllowEmptyStrings = false)]
        public string       Classes             { get; set; }


        [Display(Name = "[[[Registry]]]"), Required(ErrorMessage = "[[[Registry is required]]]", AllowEmptyStrings = false)]
        public string       RegistryId          { get; set; }
        public string       RegistryName        { get; set; }


        [Display(Name = "[[[Frequency]]]"), Required(ErrorMessage = "[[[Frequency is required]]]", AllowEmptyStrings = false)]
        public string       FrequencyId         { get; set; }
        public string       FrequencyName       { get; set; }





        [Display(Name = "[[[Owner]]]"), Required(ErrorMessage = "[[[Owner is required]]]", AllowEmptyStrings = true)]
        public string       Owner               { get; set; }
    }
}
