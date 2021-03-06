﻿using System;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Sales.Invoices.InvoiceItems;

namespace LawPanel.ApiClient.Models.Sales.FileInvoiceItems
{
    public class FileInvoiceItemDto : Dto, IIdentifiableDto
    {
        public string           Id          { get; set; }
        public Guid             FileId      { get; set; }
        public InvoiceItemDto   InvoiceItem { get; set; }
    }
}
