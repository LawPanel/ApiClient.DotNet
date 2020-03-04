using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.FilesAndFolders.FileClients
{
    public class FileClientUpdateDto : FileClientCreateDto, IIdentifiableDto
    {
        public string Id { get; set; }
    }
}
