using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Models.Sales.PaymentMethods;

namespace LawPanel.ApiClient.Models.Sales.Payments
{
    public class PaymentCreateDto : Dto 
    {
        public Guid                                     InvoiceId                       { get; set; }

        public DateTime?                                DateTime                        { get; set; }   // If null use UTC.now

        [Display(Name = "[[[Notes]]]")]
        public string                                   Description                     { get; set; }

        public Guid?                                    PaymentMethodClientId           { get; set; }

        public Guid?                                    PaymentProviderId               { get; set; }   // If null use the default (Stripe)

        [Display(Name = "[[[Payment method]]]"), Required(ErrorMessage = "[[[Payment method is required]]]")]
        public Guid                                     PaymentMethodId                 { get; set; }

        public ICollection<PaymentCreateComponentDto>   PaymentMethodComponents         { get; set; }

        public bool                                     SaveCurrentPaymentMethodData    { get; set; }

        [Display(Name = "[[[Amout]]]"), Required(ErrorMessage = "[[[Payment amount is required]]]")]
        public decimal                                  CurrencyUnits                   { get; set; }

        public bool                                     Capture                         { get; set; }

        public int?                                     PaymentStatus                   { get; set; }

    }
}