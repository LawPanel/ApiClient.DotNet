using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Firms;

namespace LawPanel.ApiClient.Models.Sales.PaymentMethods
{
    public class PaymentMethodClientDto : Dto, IIdentifiableDto
    {
        public string                                   Id                              { get; set; }
        public FirmClientDto                            FirmClient                      { get; set; }
        public PaymentProviderDto                       PaymentProvider                 { get; set; }
        public string                                   PaymentProviderEntityId         { get; set; }
        public PaymentMethodDto                         PaymentMethod                   { get; set; }
        public List<PaymentMethodComponentInstanceDto>  PaymentMethodComponentInstances { get; set; }
        public string                                   PaymentMethodSummary            { get; set; }
    }
}