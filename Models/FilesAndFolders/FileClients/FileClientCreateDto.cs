using System;

namespace LawPanel.ApiClient.Models.FilesAndFolders.FileClients
{
    public class FileClientCreateDto : Dto
    {
        public Guid     FileId              { get; set; }
        public Guid     ClientId            { get; set; }
        public Guid     FileClientRoleId    { get; set; }
        public Guid?    ClientUserId        { get; set; }
        public string   Reference           { get; set; }
    }
}
