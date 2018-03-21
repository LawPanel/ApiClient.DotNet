using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Clients;
using LawPanel.ApiClient.Models.FilesAndFolders.FileTemplates;
using LawPanel.ApiClient.Models.Firms.Portfolio;
using LawPanel.ApiClient.Models.Helpers;
using LawPanel.ApiClient.Models.Tags;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileDto : Dto, IIdentifiableDto
    {
        public string                       Id              { get; set; }
        public string                       Name            { get; set; }

        [Display(Name = "[[[File number]]]")]
        public int                          Number          { get; set; }

        public FolderDto                    Folder          { get; set; }

        [Display(Name = "[[[Tags]]]")]
        public ICollection<TagDto>          Tags            { get; set; }

        public ICollection<ShareWithDto>    ShareWiths      { get; set; }

        public ClientDto                    Client          { get; set; }

        [Display(Name = "[[[Owner]]]")]
        public UserDto                      User            { get; set; } // Owner

        [Display(Name = "[[[File status]]]")]
        public FileStatusDto                FileStatus      { get; set; }
        public FileTemplateDto              FileTemplate    { get; set; }
        public List<FileComponentDto>       Components      { get; set; }
        public string                       CreatedBy       { get; set; }
        public DateTime?                    UpdatedAt       { get; set; }
        public string                       UpdatedBy       { get; set; }


        [Display(Name = "[[[Portfolio item associated]]]")]
        public FirmPortfolioDto             FirmPortfolio   { get; set; } 
    }
}
