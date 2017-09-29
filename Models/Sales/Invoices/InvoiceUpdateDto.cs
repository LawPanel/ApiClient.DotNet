using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Sales.Invoices
{
    public class InvoiceUpdateDto : InvoiceCreateDto, IIdentifiableDto
    {
        public string Id { get; set; }
    }
}