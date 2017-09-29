using System;
using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.Sales.PaymentMethods
{
    public class PaymentMethodClientCreateDto : Dto
    {
        public Guid                                     ClientId                        { get; set; }
        public Guid                                     PaymentProviderId               { get; set; }
        public Guid                                     PaymentMethodId                 { get; set; }
        public List<PaymentMethodComponentInstanceDto>  PaymentMethodComponentInstances { get; set; }
    }
}