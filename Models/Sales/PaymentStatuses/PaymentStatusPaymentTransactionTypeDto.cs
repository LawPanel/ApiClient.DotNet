using LawPanel.ApiClient.Enums;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Sales.PaymentTransactions;

namespace LawPanel.ApiClient.Models.Sales.PaymentStatuses
{
    public class PaymentStatusPaymentTransactionTypeDto : Dto, IIdentifiableDto
    {
        public string                       Id                      { get; set; }
        public PaymentStatusDto             PaymentStatus           { get; set; }
        public PaymentTransactionTypeDto    PaymentTransactionType  { get; set; }
        public PaymentMethodType            PaymentMethodType       { get; set; }
        public decimal?                     PaymentAmount           { get; set; }
    }
}
