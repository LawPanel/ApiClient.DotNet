using System.Collections.Generic;
using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;

namespace LawPanel.ApiClient.Models.Firms.Widgets.Sales
{
    public class FirmWidgetSaleReadDto : Dto, IIdentifiableDto
    {
        public string       Id                      { get; set; }
        public string       Name                    { get; set; }
        public int          ProductModifierGroups   { get; set; }
        public int          Products                { get; set; }
        public List<string> Colors                  { get; set; }
    }
}