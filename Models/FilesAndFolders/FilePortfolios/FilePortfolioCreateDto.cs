using System;

namespace LawPanel.ApiClient.Models.FilesAndFolders.FilePortfolios
{
    public class FilePortfolioCreateDto : Dto
    {
        public Guid     FileId                  { get; set; }
        public Guid     FirmPortfolioId         { get; set; }
        public Guid     FilePortfolioRoleId     { get; set; }
    }
}