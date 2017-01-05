using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Abstractions.Base;

namespace LawPanel.ApiClient.Models.Firms.Sales.FirmProductFilters
{
    public class FirmProductFilterCreateDto : Dto
    {
        public Guid                                     FirmId                      { get; set; }

        [Display(Name = "[[[Template]]]")]
        public Guid                                     ProductFilterTemplateId     { get; set; }
        public string                                   ProductFilterTemplateName   { get; set; }

        [Display(Name = "[[[Name]]]"), Required(ErrorMessage = "[[[Filter name is required]]]")]
        public string                                   ProductFilterName           { get; set; }
        
        public List<FirmProductFilterCombinationsDto>   ProductFilterCombinations   { get; set; }

        public FirmProductFilterCreateDto()
        {
            ProductFilterCombinations=new List<FirmProductFilterCombinationsDto>();
        }
    }
}