using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;

namespace LawPanel.ApiClient.Models.ContactInfo
{
    public class ContactInfoReadDto : Dto, IIdentifiableDto
    {
        public string Id        { get; set; }
        public string CreatedAt { get; set; }
        public string Type      { get; set; }
        public string Details   { get; set; }
        
    }
}
