using LawPanel.ApiClient.Attributes;
using LawPanel.ApiClient.Constants;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.FilesAndFolders.FileClients
{
    [EndPoint(EndPoints.fileclientrole)]
    public class FileClientRoleDto : Dto, IIdentifiableDto
    {
        public string   Id      { get; set; }
        public int      Code    { get; set; }
        public string   Name    { get; set; }
    }
}
