using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileStatusDto : Dto, IIdentifiableDto
    {
        public string   Id              { get; set; }
        public string   Name            { get; set; }
        public bool     InitialState    { get; set; }
    }
}
