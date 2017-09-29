using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.FilesAndFolders.FileTemplates.ComponentDefinitions.OptionsWithText
{
    public class OptionsWithTextDefinitionDto : Dto, IComponentDefinition
    {
        public List<OptionWithDescriptionDefinitionDto> OptionWithTexts { get; set; }

        public string DisplayName()
        {
            return "[[[Multiple options with optional text field each one]]]";
        }

        public string TypeName()
        {
            return "OptionsWithText";
        }
    }

    public class OptionWithDescriptionDefinitionDto : Dto, IIdentifiableDto
    {
        public string   Id                  { get; set; }
        public string   OptionName          { get; set; }
        public string   OptionDescription   { get; set; }
        public bool     WithDescription     { get; set; }
    }
}
