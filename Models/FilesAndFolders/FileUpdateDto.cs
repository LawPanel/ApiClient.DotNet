using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileUpdateDto : Dto, IIdentifiableDto
    {
        public string                               Id              { get; set; }
        public string                               Name            { get; set; }
        public Guid                                 FileStatusId    { get; set; }
        public List<Guid>                           Tags            { get; set; }
        public List<string>                         ShareWiths      { get; set; }
        public Guid                                 UserId          { get; set; } // Owner
        public int                                  Number          { get; set; }
        public List<FileComponentCreateUpdateDto>   Components      { get; set; }
    }
}