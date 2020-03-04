using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;

using LawPanel.ApiClient.Models.Firms.Portfolio;

namespace LawPanel.ApiClient.Models.FilesAndFolders.FilePortfolios
{
    public class FilePortfolioDto : Dto, IIdentifiableDto
    {
        public string                   Id                  { get; set; }
        public FileDto                  File                { get; set; }
        
        [Display(Name = "[[[Trademark]]]")]
        public FirmPortfolioDto         FirmPortfolio       { get; set; }

        [Display(Name = "[[[Role]]]")]
        public FilePortfolioRoleDto     FilePortfolioRole   { get; set; }


        public FilePortfolioDto()
        {
            FilePortfolioRole = new FilePortfolioRoleDto();
            FirmPortfolio = new FirmPortfolioDto();
            File = new FileDto();
        }
    }
}