using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FolderCreateDto : Dto
    {
        public string               Name    { get; set; }
        public List<FileCreateDto>  Files   { get; set; }

        public FolderCreateDto()
        {
            Files=new List<FileCreateDto>();
        }
    }
}