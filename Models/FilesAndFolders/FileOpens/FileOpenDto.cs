using System;
using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Firms;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.FilesAndFolders.FileOpens
{
    public class FileOpenDto : Dto, IIdentifiableDto
    {
        public string   Id      { get; set; }
        [Display(Name = "[[[File]]]")]
        public FileDto  File    { get; set; }
        public UserDto  User    { get; set; }
        public FirmDto  Firm    { get; set; }

        public virtual DateTime DateTime { get; set; }

        public FileOpenDto()
        {
            Firm = new FirmDto();
            User = new UserDto();
            File = new FileDto();
        }
    }
}