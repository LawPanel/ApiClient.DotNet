using System;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FirmAttachmentDto : Dto, IIdentifiableDto
    {
        public string   Id          { get; set; }
        public DateTime DateTime    { get; set; }
        public string   FileName    { get; set; } // Name of attached file
        public int      FileSize    { get; set; }
        public string   Comments    { get; set; }
        public string   Url         { get; set; } // Id of BlobStorage item
        public UserDto  User        { get; set; }
    }
}
