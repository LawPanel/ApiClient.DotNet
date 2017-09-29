using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.FilesAndFolders.FileTemplates
{
    public class FileTemplateDto : Dto, IIdentifiableDto
    {
        public string                           Id                      { get; set; }
        public string                           Name                    { get; set; }
        public List<FileTemplateComponentDto>   FileTemplateComponents  { get; set; }
        public bool                             IsBase                  { get; set; }

        public FileTemplateDto()
        {
            FileTemplateComponents = new List<FileTemplateComponentDto>();
        }
    }
}
