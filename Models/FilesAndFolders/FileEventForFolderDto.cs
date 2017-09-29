using System;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileEventForFolderDto : FileEventDto
    {
        public string       FileName        { get; set; }
        public string       FileStatus      { get; set; }
        public DateTime?    FileUpdatedAt   { get; set; }
        public string       FileUpdatedBy   { get; set; }
    }
}
