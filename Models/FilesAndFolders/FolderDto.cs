using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FolderDto : Dto, IIdentifiableDto
    {
        public string           Id      { get; set; }
        public string           Name    { get; set; }
        public List<FileDto>    Files   { get; set; }

        public FolderDto()
        {
            Files = new List<FileDto>();
        }
    }
}
