using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.UserInputs
{
    public class UserInputComponentCreateUpdateDto : Dto, IIdentifiableDto
    {
        public string   Id                              { get; set; }
        public string   UserInputId                     { get; set; }
        public string   UserInputTemplateComponentId    { get; set; }
        public string   EntityId                        { get; set; } // E.g. a search ID : 309EAC4F-6E7F-462F-9BCD-A68A00F9C941
        public string   Value                           { get; set; } // E.g. "Registered" or a serialized value: { "FirstName": "Johann Sebastian", "SurName": "Bach" }
        public string   ValueBlobId                     { get; set; }
    }
}