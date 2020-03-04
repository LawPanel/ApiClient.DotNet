using System;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Helpers.UserLinks
{
    public class UserLinkReadDto : Dto, IIdentifiableDto
    {
        public string   Id          { get; set; }
        public string   Url         { get; set; } 
        public string   Comments    { get; set; }
        public DateTime UpdatedAt   { get; set; }
    }

}