using System;
using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Models.Sales;

namespace LawPanel.ApiClient.Models.Firms.Widgets.Sales
{
    public class FirmWidgetSaleCreateDto : Dto
    {
        [Display(Name = "[[[Title]]]"), Required(ErrorMessage = "[[[Title is required]]]", AllowEmptyStrings = false)]
        public string                       Name                    { get; set; }
        public Guid                         ProductFilterId         { get; set; }
        public FirmWidgetSalesSettingsDto   FirmWidgetSalesSettings { get; set; }
    }
}