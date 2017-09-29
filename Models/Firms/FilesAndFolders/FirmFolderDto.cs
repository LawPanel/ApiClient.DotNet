using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.FilesAndFolders;

namespace LawPanel.ApiClient.Models.Firms.FilesAndFolders
{
    public class FirmFolderDto : Dto, IIdentifiableDto
    {
        public string   Id      { get; set; }
        public FirmDto  Firm    { get; set; }
        public FileDto  File    { get; set; }
    }
}