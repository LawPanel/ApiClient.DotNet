using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Clients;
using LawPanel.ApiClient.Models.Sales.Invoices.InvoiceItems;
using LawPanel.ApiClient.Models.Sales.Invoices.InvoiceTypes;
using LawPanel.ApiClient.Models.Sales.Payments;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.Sales.Invoices
{
    public class InvoiceDto : Dto, IIdentifiableDto
    {
        public string                       Id              { get; set; }

        [Display(Name = "[[[Invoice date time]]]")]
        public DateTime                     DateTime        { get; set; }

        [Display(Name = "[[[Due date time]]]")]
        public DateTime                     DateTimeDue     { get; set; }

        [Display(Name = "[[[Invoice type]]]")]
        public InvoiceTypeDto               InvoiceType     { get; set; }

        [Display(Name = "[[[Invoice number]]]")]
        public int                          InvoiceNumber   { get; set; }

        [Display(Name = "[[[Client]]]")]
        public ClientDto                    Client          { get; set; }
        public ICollection<InvoiceItemDto>  InvoiceItems    { get; set; }
        public ICollection<PaymentDto>      Payments        { get; set; }
        public UserDto                      User            { get; set; }   // Creator of the invoice

        [Display(Name = "[[[Observations]]]")]
        public string                       Observations    { get; set; }



        public string DescriptiveString()
        {
            return string.Format("[[[Client: %0 - Type: %1 - Number: %2|||{0}|||{1}|||{2}]]]", Client.Name, InvoiceType.Name, InvoiceNumber);
        }
    }
}