using System;
using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileCreateDto : Dto
    {
        public string       Name                { get; set; }
        public string       Number              { get; set; }
        public Guid         FolderId            { get; set; }
        public string       FolderName          { get; set; }
        public Guid         ClientId            { get; set; } // Agent
        public Guid         UserId              { get; set; } // Owner
        public Guid         FileStatusId        { get; set; }
        public Guid         FileTemplateId      { get; set; }
        public List<string> OtherSupervisors    { get; set; }
        public bool         Active              { get; set; }

        public FileCreateDto()
        {
            OtherSupervisors = new List<string>();
        }
    }
}