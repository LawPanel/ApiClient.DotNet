using System;

namespace LawPanel.ApiClient.Models.FilesAndFolders.FileOpens
{
    public class FileOpenCreateDto : Dto
    {
        public Guid     FileId      { get; set; }
        public Guid     UserId      { get; set; }
        public Guid     FirmId      { get; set; }
        public DateTime DateTime    { get; set; }
    }
}