using LawPanel.ApiClient.Models.Firms;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileStandardLetterDto
    {
        public FirmDto Firm { get; set; }
        public UserDto User { get; set; }
    }
}