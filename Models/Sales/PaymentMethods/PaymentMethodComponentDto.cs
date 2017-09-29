using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Sales.PaymentMethods
{
    public class PaymentMethodComponentDto : Dto, IIdentifiableDto
    {
        public string                               Id                                  { get; set; }
        public string                               Value                               { get; set; } // Serialized?
        public PaymentMethodComponentDefinitionDto  PaymentMethodComponentDefinition    { get; set; }
    }
}
