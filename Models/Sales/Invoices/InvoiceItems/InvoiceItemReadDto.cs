using System;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Sales.Currencies;
using LawPanel.ApiClient.Models.Sales.Products;

namespace LawPanel.ApiClient.Models.Sales.Invoices.InvoiceItems
{
    public class InvoiceItemReadDto : Dto, IIdentifiableDto
    {
        public string           Id                  { get; set; }
        public string           Code                { get; set; }
        public string           Name                { get; set; }
        public ProductTypeDto   ProductType         { get; set; }
        public CurrencyDto      Currency            { get; set; }
        public decimal          CurrencyUnits       { get; set; } // By unit
        public decimal          Quantity            { get; set; }
        public decimal          Taxes               { get; set; }
        public string           Details             { get; set; }
        public decimal          Total               { get; set; }
        public InvoiceDto       Invoice             { get; set; }

        public string           InvoiceEntityType   { get; set; }
        public Guid             InvoiceEntityId     { get; set; }
        public string           InvoiceEntityText   { get; set; }
    }
}