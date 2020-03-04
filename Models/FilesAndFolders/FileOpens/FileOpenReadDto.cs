using System;
using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.FilesAndFolders.FileOpens
{
    public class FileOpenReadDto : Dto, IIdentifiableDto
    {
        public string   Id          { get; set; }
        [Display(Name = "[[[File]]]")]
        public FileDto  File        { get; set; }
        public UserDto  User        { get; set; }
        public DateTime DateTime    { get; set; }

        public FileOpenReadDto()
        {
            User = new UserDto();
            File = new FileDto();
        }
    }
}