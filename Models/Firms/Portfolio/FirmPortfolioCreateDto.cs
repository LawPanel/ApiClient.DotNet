using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Models.SearchClass;

namespace LawPanel.ApiClient.Models.Firms.Portfolio
{
    public class FirmPortfolioCreateDto : Dto
    {
        public string FirmId { get; set; }

        [Display(Name = "[[[Firm client]]]")]
        public string FirmClientId { get; set; }

        [Display(Name = "[[[Registry]]]"), Required(ErrorMessage = "[[[Registry is required]]]", AllowEmptyStrings = false)]
        public string RegistryId { get; set; }

        [Display(Name = "[[[Application number]]]"), Required(ErrorMessage = "[[[Registry is required]]]", AllowEmptyStrings = false)]
        public string ApplicationNumber { get; set; }

        [Display(Name = "[[[Registration date]]]")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? RegistrationDate { set; get; }

        [Display(Name = "[[[Filing date]]]")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ApplicationDate { set; get; }

        [Display(Name = "[[[Renewal date]]]")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ExpiryDate { get; set; }

        [Display(Name = "[[[Mark feature]]]")]
        public string MarkFeature { set; get; }

        [Display(Name = "[[[Mark Owner]]]")]
        public string MarkOwner { set; get; }

        [Display(Name = "[[[Kind mark]]]")]
        public string KindMark { get; set; }

        [Display(Name = "[[[Trademark]]]"), Required(ErrorMessage = "[[[Trademark is required]]]", AllowEmptyStrings = false)]
        public string MarkText { get; set; }

        [Display(Name = "[[[Classes]]]")]
        public List<SearchClassDto> Classes { get; set; }

        [Display(Name = "[[[Status]]]")]
        public string Status { get; set; }

        [Display(Name = "[[[Status date]]]")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? StatusDate { get; set; }

        [Display(Name = "[[[Image]]]")]
        public string ImageUrl { get; set; }

        public bool HasReminders { get; set; }

        [Display(Name = "[[[Case reference]]]")]
        public string CaseReference { get; set; }

        [Display(Name = "[[[Client reference]]]")]
        public string ClientReference { get; set; }

        [Display(Name = "[[[Notes]]]")]
        public string Notes { get; set; }

    }
}
