using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Sales.Invoices.InvoiceEntities
{
    public class InvoiceEntityDefinitionDto : Dto, IIdentifiableDto
    {
        public string                       Id      { get; set; }
        public string                       Name    { get; set; }
        public int                          Code    { get; set; }
        public string                       Type    { get; set; }
        public InvoiceEntityDefinitionDto   Parent  { get; set; }
    }
}