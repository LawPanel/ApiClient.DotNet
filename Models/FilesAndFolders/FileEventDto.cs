using System;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileEventDto : Dto, IIdentifiableDto
    {
        public string   Id              { get; set; }
        public Guid     FileId          { get; set; }
        public DateTime DateTime        { get; set; }
        public string   EventType       { get; set; }
        public string   By              { get; set; } // Who created the event?
        public string   Comments        { get; set; } 
    }
}