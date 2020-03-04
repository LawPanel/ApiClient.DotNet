using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Attributes;
using LawPanel.ApiClient.Constants;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.FilesAndFolders.FileTemplates
{
    [EndPoint(EndPoints.firmfiletemplate)]
    public class FileTemplateDto : Dto, IIdentifiableDto
    {
        public string                           Id                              { get; set; }
        public string                           Name                            { get; set; }
        public List<FileTemplateComponentDto>   FileTemplateComponents          { get; set; }
        public bool                             IsBase                          { get; set; }
        public bool                             IsTemplateForTrademarkFiling    { get; set; }
        public Guid                             BaseId                          { get; set; }

        public FileTemplateDto()
        {
            FileTemplateComponents = new List<FileTemplateComponentDto>();
        }
    }
}
