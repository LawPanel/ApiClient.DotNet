using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.FilesAndFolders;

namespace LawPanel.ApiClient.Models.Firms.FilesAndFolders
{
    public class FirmFileDto : Dto, IIdentifiableDto
    {
        public string   Id      { get; set; }
        public FirmDto  Firm    { get; set; }
        public FileDto  FileDto { get; set; }
    }
}
