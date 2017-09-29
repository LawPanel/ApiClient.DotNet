using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Clients;

namespace LawPanel.ApiClient.Models.Sales.PaymentMethods
{
    public class PaymentMethodClientReadDto : Dto, IIdentifiableDto //, IPaymentProviderEntity
    {
        public string               Id                          { get; set; }
        public ClientDto            Client                      { get; set; }
        public PaymentProviderDto   PaymentProvider             { get; set; }
        public PaymentMethodDto     PaymentMethod               { get; set; }
        public string               PaymentMethodClientSummary  { get; set; }
        public string               PaymentProviderEntityId     { get; set; }
    }
}