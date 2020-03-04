using LawPanel.ApiClient.Models.UserInputTemplates;

namespace LawPanel.ApiClient.Models.UserInputs
{
    public class UserInputComponentRepresentationDto : Dto
    {
        public UserInputDto                     UserInputDto                     { get; set; }
        public UserInputTemplateComponentDto    UserInputTemplateComponentDto    { get; set; }
        public UserInputComponentDto            UserInputComponentDto            { get; set; }
        public bool                             ReadOnly                         { get; set; }
    }
}