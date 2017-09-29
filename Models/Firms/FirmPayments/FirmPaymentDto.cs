using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Sales.Payments;

namespace LawPanel.ApiClient.Models.Firms.FirmPayments
{
    public class FirmPaymentDto: Dto, IIdentifiableDto
    {
        public string       Id      { get; set; }
        public FirmDto      Firm    { get; set; }
        public PaymentDto   Payment { get; set; }
    }
}