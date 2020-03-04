using System;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileEventDto : Dto, IIdentifiableDto
    {
        #region Coordinates
        public Guid?    FileId          { get; set; }
        public Guid?    FolderId        { get; set; }
        public Guid?    UserId          { get; set; }
        public Guid?    FirmId          { get; set; }
        public string   ClientId        { get; set; }
        #endregion

        public string   Id              { get; set; }
        public DateTime DateTime        { get; set; }
        public string   EventType       { get; set; }
        public string   By              { get; set; } // Who created the event?
        public string   ById            { get; set; } 

        public string   Comments        { get; set; } 
    }
}