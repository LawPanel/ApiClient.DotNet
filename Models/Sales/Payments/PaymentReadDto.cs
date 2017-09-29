using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Sales.Currencies;
using LawPanel.ApiClient.Models.Sales.PaymentStatuses;
using LawPanel.ApiClient.Models.Sales.PaymentTransactions;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.Sales.Payments
{
    public class PaymentReadDto : Dto, IIdentifiableDto
    {
        public string                                       Id                      { get; set; }
        public long                                         DateTime                { get; set; }
        public PaymentProviderDto                           PaymentProvider         { get; set; }
        public string                                       PaymentMethodName       { get; set; }
        public string                                       PaymentMethodDetails    { get; set; }
        public PaymentStatusDto                             PaymentStatus           { get; set; }
        public CurrencyDto                                  Currency                { get; set; }
        public decimal                                      CurrencyUnits           { get; set; }
        public List<PaymentStatusPaymentTransactionTypeDto> TransactionsAvailable   { get; set; }
        public List<PaymentTransactionDto>                  PaymentTransactions     { get; set; }
        public UserDto                                      User                    { get; set; }
    }
}
