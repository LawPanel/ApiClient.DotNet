using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Sales.PaymentMethods
{
    public class PaymentMethodComponentInstanceDto : Dto, IIdentifiableDto
    {
        public string                               Id                                  { get; set; }
        public PaymentMethodComponentDefinitionDto  PaymentMethodComponentDefinition    { get; set; }
        public string                               Value                               { get; set; } // Serialized?
    }
}