using LawPanel.ApiClient.Models.FilesAndFolders.FileTemplates;
using LawPanel.ApiClient.Models.Firms;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileComponentRepresentationDto : Dto
    {
        public FileDto                  FileDto                     { get; set; }
        public FileTemplateComponentDto FileTemplateComponentDto    { get; set; }
        public FileComponentDto         FileComponentDto            { get; set; }
        public FirmDto                  FirmDto                     { get; set; }
        public UserDto                  UserDto                     { get; set; }
    }
}