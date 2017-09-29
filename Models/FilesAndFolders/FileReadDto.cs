using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Tags;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileReadDto : Dto, IIdentifiableDto
    {
        public string           Id              { get; set; }
        public string           Name            { get; set; }
        public Guid             ClientId        { get; set; }
        public string           ClientName      { get; set; }
        public Guid             FileStatusId    { get; set; }
        public string           FileStatusName  { get; set; }
        public Guid             OwnerId         { get; set; }
        public string           OwnerUserName   { get; set; } // Owner
        public DateTime?        UpdatedAt       { get; set; }
        public string           PaymentStatus   { get; set; }
        public string           UpdatedBy       { get; set; } // Last updated by
        public List<TagDto>     Tags            { get; set; }

        public FileReadDto()
        {
            Tags = new List<TagDto>();
        }
    }
}