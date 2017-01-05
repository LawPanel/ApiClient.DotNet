using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;

namespace LawPanel.ApiClient.Models.Sales
{
    public class ProductFilterTemplateDto : Dto, IIdentifiableDto
    {
        public string                           Id                      { get; set; }
        [Display(Name = "[[[Template name]]]"), Required(ErrorMessage = "[[[Template name is required]]]", AllowEmptyStrings = false)]
        public string                           Name                    { get; set; }
        public bool                             IsBase                  { get; set; }
        public Guid                             PersonalizationOf       { get; set; }
        public List<ProductModifierGroupDto>    ProductModifierGroups   { get; set; }

        public ProductFilterTemplateDto()
        {
            ProductModifierGroups = new List<ProductModifierGroupDto>();
        }
    }
}
