using System;
using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileCloneCreateDto : Dto
    {
        public string     Name       { get; set; }
        public string     Number     { get; set; }
        public List<Guid> Registries { get; set; }

        public FileCloneCreateDto()
        {
            Registries = new List<Guid>();
        }
    }
}