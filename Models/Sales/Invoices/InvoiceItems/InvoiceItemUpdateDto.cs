using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Sales.Invoices.InvoiceItems
{
    public class InvoiceItemUpdateDto : InvoiceItemCreateDto, IIdentifiableDto
    {
        public string   Id          { get; set; }
    }
}
