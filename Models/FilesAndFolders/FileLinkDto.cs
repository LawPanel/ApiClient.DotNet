using System;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileLinkDto : Dto, IIdentifiableDto
    {
        public string   Id          { get; set; }
        public FileDto  File        { get; set; }
        public DateTime DateTime    { get; set; }
        public string   Comments    { get; set; }
        public string   Url         { get; set; } 
        public UserDto  User        { get; set; }
    }
}
