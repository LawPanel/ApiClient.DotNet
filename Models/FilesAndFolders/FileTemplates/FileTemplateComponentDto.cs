using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.FilesAndFolders.FileTemplates
{
    public class FileTemplateComponentDto : Dto, IIdentifiableDto
    {
        public string       Id              { get; set; }
        public string       Name            { get; set; }
        public string       Description     { get; set; }
        public string       Definition      { get; set; } // Definition serialized 
        public string       DefinitionType  { get; set; } // Definition type name. E.g.: OptionsWitText
        public string       EntityType      { get; set; } // E.g.: Search. The instance asociated with this component.
        public List<string> Permissions     { get; set; } // With format: "Action|Entity|Id" - e.g.: View|Client|* ( all clients can view ) / Edit|Firm|309EAC4F-6E7F-462F-9BCD-A68A00F9C941 ( all into firm 309EAC4F-6E7F-462F-9BCD-A68A00F9C941 can edit )
        public bool         Required        { get; set; }
        public string       RegexToValidate { get; set; }
        public bool         MultipleValues  { get; set; }
        public int          DisplayOrder    { get; set; }
        public string       ValueType       { get; set; } // What type is accepted as value?
    }
}
    