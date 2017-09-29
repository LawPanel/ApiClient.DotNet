using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LawPanel.ApiClient.Models.Sales.Invoices
{
    public class InvoiceCreateDto : Dto
    {
        [Display(Name = "[[[Date]]]")]
        [Required(ErrorMessage = "[[[Invoice date is required]]]")]
        public long         DateTime        { get; set; }

        [Display(Name = "[[[Due date time]]]")]
        public long         DateTimeDue     { get; set; }

        [Display(Name = "[[[Invoice type]]]")]
        public Guid         InvoiceTypeId   { get; set; }

        [Display(Name = "[[[Invoice number]]]")]
        public int          InvoiceNumber   { get; set; }

        [Display(Name = "[[[Invoice items]]]")]
        public List<Guid>   InvoiceItemsIds { get; set; }

        [Display(Name = "[[[Client]]]")]
        public Guid         ClientId        { get; set; }

        [Display(Name = "[[[User]]]")]
        public Guid         UserId          { get; set; }

        [Display(Name = "[[[Observations]]]")]
        public string       Observations     { get; set; }
    }
}