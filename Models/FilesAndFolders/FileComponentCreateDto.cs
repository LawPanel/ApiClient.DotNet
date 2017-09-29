using System;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileComponentCreateDto : Dto
    {
        public Guid     FileId                  { get; set; }
        public Guid     FileTemplateComponentId { get; set; }
        public string   EntityId                { get; set; } // E.g. a search ID : 309EAC4F-6E7F-462F-9BCD-A68A00F9C941
        public string   Value                   { get; set; }
        public string   ValueBlobId             { get; set; }
    }
}