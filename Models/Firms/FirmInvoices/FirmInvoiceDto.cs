using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Sales.Invoices;

namespace LawPanel.ApiClient.Models.Firms.FirmInvoices
{
    public class FirmInvoiceDto : Dto, IIdentifiableDto
    {
        public string       Id      { get; set; }
        public FirmDto      Firm    { get; set; }
        public InvoiceDto   Invoice { get; set; }
    }
}