using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Sales.PaymentMethods
{
    public class PaymentMethodClientUpdateDto : Dto, IIdentifiableDto
    {
        public string                                       Id                                      { get; set; }
        public List<PaymentMethodClientUpdateComponentDto>  PaymentMethodClientUpdateComponentDtos  { get; set; }
    }
}