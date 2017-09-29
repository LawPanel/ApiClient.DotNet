using System.Collections.Generic;
using LawPanel.ApiClient.Models.Sales.Invoices.InvoiceItems;

namespace LawPanel.ApiClient.Models.Sales.Invoices.InvoiceEntities
{
    public class InvoiceEntityInstanceWithItemsDto 
    {
        public InvoiceEntityInstanceDto                 InvoiceEntityInstance   { get; set; }
        public List<InvoiceItemReadDto>                 InvoiceItems            { get; set; } 
        public List<InvoiceEntityInstanceWithItemsDto>  Children                { get; set; }
    }
}