using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileLinkUpdateDto : FileLinkCreateDto, IIdentifiableDto
    {
        public string Id { get; set; }
    }
}
