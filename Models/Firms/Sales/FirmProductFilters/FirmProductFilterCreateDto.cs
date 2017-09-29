using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LawPanel.ApiClient.Models.Firms.Sales.FirmProductFilters
{
    public class FirmProductFilterCreateDto : Dto
    {
        public Guid                                     FirmId                      { get; set; }

        [Display(Name = "[[[Template]]]")]
        public Guid                                     ProductFilterTemplateId     { get; set; }
        public string                                   ProductFilterTemplateName   { get; set; }

        [Display(Name = "[[[Public name]]]"), Required(ErrorMessage = "[[[Filter public name is required]]]")]
        public string                                   ProductFilterName           { get; set; }
        
        public List<FirmProductFilterCombinationsDto>   ProductFilterCombinations   { get; set; }

        public FirmProductFilterCreateDto()
        {
            ProductFilterCombinations=new List<FirmProductFilterCombinationsDto>();
        }
    }
}