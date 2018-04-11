using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Sales;

namespace LawPanel.ApiClient.Models.Firms
{
    public class FirmDto : Dto, IIdentifiableDto
    {
        public string               Id              { get; set; }

        [Display(Name = "[[[Firm name]]]"), Required(ErrorMessage = "[[[Firm name is required]]]", AllowEmptyStrings = false)]
        public string               Name            { get; set; }
        public FirmUiSettingsDto    FirmSettings    { get; set; }

        [Display(Name = "[[[Site]]]"), Required(ErrorMessage = "[[[Site name is required]]]", AllowEmptyStrings = false)]
        public string               TenantName      { get; set; }

        [Display(Name = "[[[API subscription key]]]")]
        public string               SubscriptionKey { get; set; }

        [Display(Name = "[[[Firm email]]]")]
        public string               Email           { get; set; }

        [Display(Name = "[[[Firm phone number]]]")]
        public string               PhoneNumber     { get; set; }

        [Display(Name = "[[[Payment provider]]]")]
        public PaymentProviderDto   PaymentProvider { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}