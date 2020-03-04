using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.FilesAndFolders.FileTemplates;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileComponentDto : Dto, IIdentifiableDto
    {
        public string                   Id                      { get; set; }
        public FileDto                  File                    { get; set; }
        public FileTemplateComponentDto FileTemplateComponent   { get; set; }
        public string                   EntityId                { get; set; } // E.g. a search ID : 309EAC4F-6E7F-462F-9BCD-A68A00F9C941
        public string                   Value                   { get; set; }
        public string                   ValueBlobId             { get; set; }
    }
}
