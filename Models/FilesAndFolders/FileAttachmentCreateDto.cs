using System;
using System.ComponentModel.DataAnnotations;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileAttachmentCreateDto : Dto
    {
        [Required(AllowEmptyStrings = false)]
        public Guid     FileId      { get; set; }

        [Display(Name = "[[[File name]]]"), Required(ErrorMessage = "[[[File name is required]]]", AllowEmptyStrings = false)]
        public string   FileName    { get; set; } // Name of attached file

        public int      FileSize    { get; set; }

        [Display(Name = "[[[Comments]]]")]
        public string   Comments    { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "[[[Please select a file to upload]]]")]
        public string   Url         { get; set; } // Id of BlobStorage item
    }
}
