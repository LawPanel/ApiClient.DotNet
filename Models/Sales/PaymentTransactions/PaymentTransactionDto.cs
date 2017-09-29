using System;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Sales.PaymentTransactions
{
    public class PaymentTransactionDto : Dto, IIdentifiableDto
    {
        public string                       Id                              { get; set; }
        public Guid                         PaymentId                       { get; set; }
        public long                         DateTime                        { get; set; }
        public PaymentTransactionStatusDto  PaymentTransactionStatus        { get; set; }
        public PaymentTransactionTypeDto    PaymentTransactionType          { get; set; }
        public string                       Response                        { get; set; }
        public string                       Notes                           { get; set; }
        public string                       PaymentProviderTransactionId    { get; set; }
        public decimal                      Amount                          { get; set; }
    }
}
