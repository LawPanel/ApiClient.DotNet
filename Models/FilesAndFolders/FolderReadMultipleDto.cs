using System;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FolderReadMultipleDto : Dto, IIdentifiableDto
    {
        public string   Id              { get; set; }
        public string   Name            { get; set; }
        public Guid     ClientId        { get; set; }
        public string   ClientName      { get; set; }
        public DateTime FileUpdatedAt   { get; set; }
        public string   TagsId          { get; set; }
        public string   FileName        { get; set; }
    }
}