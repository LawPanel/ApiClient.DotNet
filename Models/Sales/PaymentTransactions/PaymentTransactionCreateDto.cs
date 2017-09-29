using System;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Sales.PaymentTransactions
{
    public class PaymentTransactionCreateDto : Dto, IIdentifiableDto
    {
        public string   Id                              { get; set; }
        public Guid     PaymentId                       { get; set; }
        public DateTime DateTime                        { get; set; }
        public int      PaymentTransactionStatusCode    { get; set; }
        public int      PaymentTransactionTypeCode      { get; set; }
        public string   Notes                           { get; set; }
        public string   Response                        { get; set; }
        public string   PaymentProviderTransactionId    { get; set; }
        public decimal  Amount                          { get; set; }
    }
}
