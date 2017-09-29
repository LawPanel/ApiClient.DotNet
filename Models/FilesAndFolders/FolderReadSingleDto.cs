using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FolderReadSingleDto : Dto, IIdentifiableDto
    {
        public string               Id          { get; set; }
        public string               Name        { get; set; }
        public List<FileReadDto>    Files       { get; set; }
        public string               CreatedBy   { get; set; }
        public DateTime?            UpdatedAt   { get; set; }
        public string               UpdatedBy   { get; set; }
    }
}