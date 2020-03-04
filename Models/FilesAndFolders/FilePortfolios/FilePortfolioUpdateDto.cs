using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.FilesAndFolders.FilePortfolios
{
    public class FilePortfolioUpdateDto : FilePortfolioCreateDto, IIdentifiableDto
    {
        public string Id { get; set; }
    }
}
