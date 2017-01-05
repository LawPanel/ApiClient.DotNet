using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;
using LawPanel.ApiClient.Models.Sales;

namespace LawPanel.ApiClient.Models.Firms.Sales.FirmProducts
{
    public class FirmProductCreateDto : Dto, IIdentifiableDto
    {
        public string       Id                  { get; set; }

        public Guid         FirmId              { get; set; }

        public Guid         ProductId           { get; set; }

        [Display(Name = "[[[Code]]]"), Required(ErrorMessage = "[[[Fee item code (number) is required]]]")]
        public int          ProductCode         { get; set; }

        [Display(Name = "[[[Name]]]"), Required(ErrorMessage = "[[[Fee item name is required]]]")]
        public string       ProductName         { get; set; }

        [Display(Name = "[[[Public label]]]"), Required(ErrorMessage = "[[[Fee item name is required]]]")]
        public string       ProductNamePublic   { get; set; }
        
        public Guid         ProductTypeId       { get; set; }

        [Display(Name = "[[[Currency]]]"), Required(ErrorMessage = "[[[Fee item currency is required]]]")]
        public Guid         CurrencyId          { get; set; }
        public string CurrencyName { get; set; }

        [Display(Name = "[[[Amount]]]"), Required(ErrorMessage = "[[[Fee item amount is required]]]")]
        public decimal      Value               { get; set; }

        [Display(Name = "[[[Taxes]]]")]
        public List<TaxDto> Taxes               { get; set; } 
    }
}
