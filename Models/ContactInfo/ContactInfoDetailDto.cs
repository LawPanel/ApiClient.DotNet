using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.ContactInfo
{
    public class ContactInfoDetailDto : Dto,IIdentifiableDto
    {
        public string                               Id                              { get; set; }
        public ContactInfoComponentDefinitionDto    ContactInfoComponentDefinition  { get; set; }
        public string                               Value                           { get; set; }
    }
}
