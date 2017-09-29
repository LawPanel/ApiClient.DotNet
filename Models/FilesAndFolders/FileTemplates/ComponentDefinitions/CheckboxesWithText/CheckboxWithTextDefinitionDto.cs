namespace LawPanel.ApiClient.Models.FilesAndFolders.FileTemplates.ComponentDefinitions.CheckboxesWithText
{
    public class CheckboxWithTextDefinitionDto : Dto, IComponentDefinition
    {
        public string Id    { get; set; }

        public string DisplayName()
        {
            return "[[[One checkbox with a dependent text to be filled when is checked]]]";
        }

        public string TypeName()
        {
            return "CheckboxWithText";
        }
    }

   
}
