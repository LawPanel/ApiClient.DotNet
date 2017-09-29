using System;
using System.ComponentModel.DataAnnotations;

namespace LawPanel.ApiClient.Models.Firms
{
    public class FirmUpdateDto : FirmDto
    {
        public Guid     PaymentProviderId                   { get; set; }

        [Display(Name = "[[[Payment provider secret API Key]]]")]
        public string   PaymentProviderApiKey               { get; set; }

        [Display(Name = "[[[Payment provider publishable API Key]]]")]
        public string   PaymentProviderPublishableApiKey    { get; set; }
    }
}