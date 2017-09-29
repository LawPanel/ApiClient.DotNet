using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LawPanel.ApiClient.Models.Sales.Invoices.InvoiceItems
{
    public class InvoiceItemCreateDto : Dto
    {
        [Display(Name = "[[[Code]]]")]
        public string               Code                        { get; set; }

        [Display(Name = "[[[Name]]]"), Required(ErrorMessage = "[[[Name is required]]]", AllowEmptyStrings = false)]
        public string               Name                        { get; set; }

        [Display(Name = "[[[Details]]]")]
        public string               Details                     { get; set; }

        [Display(Name = "[[[Product type]]]")]
        public Guid                 ProductTypeId               { get; set; }

        [Display(Name = "[[[Currency]]]"), Required(ErrorMessage = "[[[ID of currency is a required value]]]")]
        public Guid                 CurrencyId                  { get; set; }

        [Display(Name = "[[[Unit price]]]")]
        public decimal              CurrencyUnits               { get; set; } // By unit

        [Display(Name = "[[[Quantity]]]")]
        public decimal              Quantity                    { get; set; }

        [Display(Name = "[[[Taxes]]]")]
        public List<Guid>           Taxes                       { get; set; }

        public string               InvoiceEntityType           { get; set; }
        public Guid                 InvoiceEntityId             { get; set; }
    }
}
