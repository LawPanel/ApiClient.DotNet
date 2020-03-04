using LawPanel.ApiClient.Attributes;
using LawPanel.ApiClient.Constants;

namespace LawPanel.ApiClient.Models.FilesAndFolders.FileTemplates
{
    [EndPoint(EndPoints.firmfiletemplate)]
    public class FileTemplateReadDto : FileTemplateDto
    {
        public int Cases { get; set; }
    }
}
