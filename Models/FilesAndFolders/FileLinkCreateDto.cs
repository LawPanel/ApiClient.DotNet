using System;
using System.ComponentModel.DataAnnotations;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileLinkCreateDto : Dto
    {
        [Required(AllowEmptyStrings = false)]
        public Guid     FileId      { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "[[[Please enter the URL to save]]]")]
        public string Url { get; set; } // Id of BlobStorage item

        [Display(Name = "[[[Comments]]]")]
        public string   Comments    { get; set; }
    }
}