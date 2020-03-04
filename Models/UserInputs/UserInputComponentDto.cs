using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.UserInputTemplates;

namespace LawPanel.ApiClient.Models.UserInputs
{
    public class UserInputComponentDto : Dto, IIdentifiableDto
    {
        public string                           Id                          { get; set; }
        public UserInputDto                     UserInput                   { get; set; }
        public UserInputTemplateComponentDto    UserInputTemplateComponent  { get; set; }
        public string                           EntityId                    { get; set; } // E.g. a search ID : 309EAC4F-6E7F-462F-9BCD-A68A00F9C941
        public string                           Value                       { get; set; } // E.g. "Registered" or a serialized value: { "FirstName": "Johann Sebastian", "SurName": "Bach" }
        public string                           ValueBlobId                 { get; set; }

        public override string ToString()
        {
            return $"Template name: {UserInput.UserInputTemplate.Name} / Notes: {UserInput.Notes} / Value: {Value}";
        }
    }
}
