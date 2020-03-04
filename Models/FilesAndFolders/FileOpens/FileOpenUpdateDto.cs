using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.FilesAndFolders.FileOpens
{
    public class FileOpenUpdateDto : FileOpenCreateDto, IIdentifiableDto
    {
        public string Id { get; set; }
    }
}
