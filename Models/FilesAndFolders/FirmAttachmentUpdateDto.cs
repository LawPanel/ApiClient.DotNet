using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FirmAttachmentUpdateDto : FirmAttachmentCreateDto, IIdentifiableDto
    {
        public string Id { get; set; }
    }
}
