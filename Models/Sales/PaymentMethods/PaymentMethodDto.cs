using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Sales.PaymentMethods
{
    public class PaymentMethodDto : Dto, IIdentifiableDto
    {
        public string                                       Id                                  { get; set; }
        public int                                          Code                                { get; set; }
        public string                                       Name                                { get; set; }
        public string                                       Description                         { get; set; }
        public List<PaymentMethodComponentDefinitionDto>    PaymentMethodComponentDefinitions   { get; set; }
        public bool                                         Reusable                            { get; set; }
    }
}
