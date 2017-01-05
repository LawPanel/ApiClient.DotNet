using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;

namespace LawPanel.ApiClient.Models.Firms.Sales.FirmProductFilters
{
    public class FirmProductFilterCombinationsDto : Dto, IIdentifiableDto
    {
        public string     Id                            { get; set; }
        public List<Guid> ProductModifierDefinitions    { get; set; }
        public List<Guid> Products                      { get; set; }

        public FirmProductFilterCombinationsDto()
        {
            ProductModifierDefinitions = new List<Guid>();
            Products = new List<Guid>();
        }

        
    }
}