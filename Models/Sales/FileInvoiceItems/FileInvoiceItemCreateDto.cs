using System;
using LawPanel.ApiClient.Models.Sales.Invoices.InvoiceItems;

namespace LawPanel.ApiClient.Models.Sales.FileInvoiceItems
{
    public class FileInvoiceItemCreateDto : Dto
    {
        public Guid                     FileId          { get; set; }
        public InvoiceItemCreateDto     InvoiceItem     { get; set; } // Name of attached file
    }
}
