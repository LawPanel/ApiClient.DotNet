using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.FilesAndFolders.FilePortfolios
{
    public class FilePortfolioRoleDto : Dto, IIdentifiableDto
    {
        public string   Id      { get; set; }
        public int      Code    { get; set; }
        public string   Name    { get; set; }
        public bool     IsOwn   { get; set; }
    }
}
