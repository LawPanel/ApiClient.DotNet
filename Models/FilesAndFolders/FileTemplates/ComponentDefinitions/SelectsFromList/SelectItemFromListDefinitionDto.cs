using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.FilesAndFolders.FileTemplates.ComponentDefinitions.SelectsFromList
{
    public class SelectItemFromListDefinitionDto : Dto, IComponentDefinition
    {
        public List<ItemDefinitionDto> Items { get; set; }

        public string DisplayName()
        {
            return "[[[Item selectable from list]]]";
        }

        public string TypeName()
        {
            return "SelectItemFromList";
        }
    }

    public class ItemDefinitionDto : Dto
    {
        public string   Display { get; set; }
        public string   Value   { get; set; }
    }
}
