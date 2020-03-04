using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileUpdateDto : Dto, IIdentifiableDto
    {
        public string                               Id                  { get; set; }
        public string                               Name                { get; set; }
        public Guid                                 FileStatusId        { get; set; }
        public Guid?                                FileClientId        { get; set; }
        public List<Guid>                           Tags                { get; set; }
        public List<Guid>                           OtherSupervisors    { get; set; }
        public Guid                                 UserId              { get; set; } // Owner
        public string                               Number              { get; set; }
        public List<FileComponentCreateUpdateDto>   Components          { get; set; }
        public bool                                 Active              { get; set; }
    }
}