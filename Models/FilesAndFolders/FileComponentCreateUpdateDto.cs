using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileComponentCreateUpdateDto : Dto, IIdentifiableDto
    {
        public string Id                        { get; set; }
        public string FileTemplateComponentId   { get; set; }
        public string EntityId                  { get; set; }
        public string Value                     { get; set; }
        public string ValueBlobId               { get; set; }
    }
}