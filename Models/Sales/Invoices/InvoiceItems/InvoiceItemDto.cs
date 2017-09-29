using System;
using System.Collections.Generic;
using System.Linq;
using LawPanel.ApiClient.Extensions;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Sales.Currencies;
using LawPanel.ApiClient.Models.Sales.Products;

namespace LawPanel.ApiClient.Models.Sales.Invoices.InvoiceItems
{
    public class InvoiceItemDto : Dto, IIdentifiableDto
    {
        public string               Id                  { get; set; }
        public string               Code                { get; set; }
        public string               Name                { get; set; }
        public ProductTypeDto       ProductType         { get; set; }
        public CurrencyDto          Currency            { get; set; }
        public decimal              CurrencyUnits       { get; set; } // By unit
        public decimal              Quantity            { get; set; }
        public ICollection<TaxDto>  Taxes               { get; set; }
        public string               Details             { get; set; }
        public bool                 PaidOut             { get; set; }
        public string               InvoiceEntityType   { get; set; }
        public Guid                 InvoiceEntityId     { get; set; }



        #region Helpers

        public decimal Total()
        {
            return CurrencyUnits*Quantity;
        }

        public string TaxesAsString()
        {
            if (Taxes == null || !Taxes.Any()) return string.Empty;

            return Taxes.Select(t => t.Name).ToList().CommaSeparatedItems();
        }


        public decimal TotalTaxesPercent()
        {
            if (Taxes == null) return 0;
            return Taxes.Sum(t => t.Percent);
        }

        public decimal TotalTaxesValue()
        {
            if (Taxes == null) return 0;

            var percent = Taxes.Sum(t => t.Percent);
            var units = Taxes.Sum(t => t.Units);

            var percentValue = (Total() * percent) / 100;

            return percentValue + units;
        }
        #endregion

    }



    

}
