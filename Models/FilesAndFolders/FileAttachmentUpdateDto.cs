using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileAttachmentUpdateDto : FileAttachmentCreateDto, IIdentifiableDto
    {
        public string Id { get; set; }
    }
}
