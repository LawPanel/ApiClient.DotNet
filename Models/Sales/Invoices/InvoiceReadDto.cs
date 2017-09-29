using System;
using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Clients;
using LawPanel.ApiClient.Models.Sales.Currencies;
using LawPanel.ApiClient.Models.Sales.Invoices.InvoiceTypes;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.Sales.Invoices
{
    public class InvoiceReadDto : Dto,IIdentifiableDto
    {
        public string                   Id                      { get; set; }

        [Display(Name = "[[[Creation date time]]]")]
        public DateTime                 DateTime                { get; set; }

        [Display(Name = "[[[Due date time]]]")]
        public DateTime                 DateTimeDue             { get; set; }

        [Display(Name = "[[[Invoice type]]]")]
        public InvoiceTypeDto           InvoiceType             { get; set; }

        [Display(Name = "[[[Invoice number]]]")]
        public int                      InvoiceNumber           { get; set; }

        [Display(Name = "[[[Client]]]")]
        public ClientDto                Client                  { get; set; }

        [Display(Name = "[[[Total invoice]]]")]
        public decimal                  TotalInvoiceItems       { get; set; }

        [Display(Name = "[[[Total payments]]]")]
        public decimal                  TotalPayments           { get; set; }

        [Display(Name = "[[[Created by]]]")]
        public UserDto                  User                    { get; set; }   // Creator of the invoice

        [Display(Name = "[[[Currency]]]")]
        public CurrencyDto              Currency                { get; set; }   // For now, just one currency. Me duele el mate, tengo migrañas con auras y no soy Vincent, no me rompan los huevos.

        [Display(Name = "[[[Observations]]]")]
        public string                   Observations            { get; set; }
    }
}
