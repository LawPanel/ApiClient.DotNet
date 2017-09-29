using System;

namespace LawPanel.ApiClient.Models.Sales.Invoices.InvoiceEntities
{
    public class InvoiceEntityInstanceDto : Dto 
    {
        public Guid                         InvoiceEntityId             { get; set; }
        public string                       InvoiceEntityDisplayText    { get; set; }
        public InvoiceEntityDefinitionDto   InvoiceEntityDefinition     { get; set; }
    }
}