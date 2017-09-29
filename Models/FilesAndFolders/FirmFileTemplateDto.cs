using System;
using LawPanel.ApiClient.Models.FilesAndFolders.FileTemplates;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FirmFileTemplateDto : FileTemplateDto
    {
        public Guid FirmId { get; set; }
    }
}
