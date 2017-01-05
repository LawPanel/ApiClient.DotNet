using System.Collections.Generic;
using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;

namespace LawPanel.ApiClient.Models.Sales
{
    public class ProductFilterDto : Dto, IIdentifiableDto
    {
        public string                       Id                      { get; set; }
        public string                       Name                    { get; set; }
        public List<ProductFilterDetailDto> ProductFilterDetails    { get; set; }
    }
}
