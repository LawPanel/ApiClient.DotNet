using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Sales.Currencies;
using LawPanel.ApiClient.Models.Sales.PaymentMethods;
using LawPanel.ApiClient.Models.Sales.PaymentStatuses;
using LawPanel.ApiClient.Models.Sales.PaymentTransactions;

namespace LawPanel.ApiClient.Models.Sales.Payments
{
    public class PaymentDto : Dto, IIdentifiableDto
    {
        public string                                       Id                                      { get; set; }
        public DateTime                                     DateTime                                { get; set; }
        public PaymentProviderDto                           PaymentProvider                         { get; set; }
        public PaymentMethodDto                             PaymentMethod                           { get; set; }
        public string                                       PaymentMethodDetails                    { get; set; }
        public List<PaymentMethodComponentInstanceDto>      PaymentMethodComponentInstances         { get; set; }
        public PaymentStatusDto                             PaymentStatus                           { get; set; }
        public CurrencyDto                                  Currency                                { get; set; }
        public decimal                                      CurrencyUnits                           { get; set; }
        public List<PaymentStatusPaymentTransactionTypeDto> PaymentStatusPaymentTransactionTypes    { get; set; }
        public ICollection<PaymentTransactionDto>           PaymentTransactions                     { get; set; }
        public string                                       PaymentProviderEntityId                 { get; set; }
    }
}
