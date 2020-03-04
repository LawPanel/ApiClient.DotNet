using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Clients;
using LawPanel.ApiClient.Models.Sales.Invoices;
using LawPanel.ApiClient.Models.Searches;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileReadTmdDto : Dto, IIdentifiableDto
    {
        public string                   Id                  { get; set; }
        public string                   Name                { get; set; }
        public ClientDto                Client              { get; set; }
        public Guid                     FileStatusId        { get; set; }
        public string                   FileStatusName      { get; set; }
        public string                   FolderName          { get; set; }
        public Guid                     OwnerId             { get; set; }
        public string                   OwnerUserName       { get; set; } 
        public DateTime?                UpdatedAt           { get; set; }
        public string                   PaymentStatus       { get; set; }
        public string                   UpdatedBy           { get; set; } 
        public string                   Number              { get; set; }
        public Guid                     FileTemplateId      { get; set; }
        public string                   FileTemplateName    { get; set; }

        public InvoiceDto               Invoice             { get; set; }
        public decimal                  TotalPayments       { get; set; }
        public decimal                  TotalInvoiceItems   { get; set; }
        public decimal                  TotalInvoiceTaxes   { get; set; }

        public List<FileComponentDto>   FileComponents      { get; set; }
        public List<FileEventDto>       FileEvents          { get; set; } 
        public DateTime                 Created             { get; set; }
        public DateTime?                Updated             { get; set; }

        public SearchDto                Searches            { get; set; }
      
    }
}