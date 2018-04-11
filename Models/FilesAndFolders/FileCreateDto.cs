using System;
using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileCreateDto : Dto
    {
        public string       Name            { get; set; }
        public int          Number          { get; set; }
        public Guid         FolderId        { get; set; }
        public string       FolderName      { get; set; }
        public Guid         ClientId        { get; set; }
        public string       ClientName      { get; set; }
        public Guid         UserId          { get; set; } // Owner
        public Guid         FileStatusId    { get; set; }
        public Guid         FileTemplateId  { get; set; }
        public List<string> ShareWiths      { get; set; }
    }
}