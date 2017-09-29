using System;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileCreateIntoFolderDto : Dto
    {
        public string   Name            { get; set; }
        public int      Number          { get; set; }
        public Guid     ClientId        { get; set; }
        public Guid     UserId          { get; set; } // Owner
        public Guid     FileStatusId    { get; set; }
        public Guid     FileTemplateId  { get; set; }
    }
}