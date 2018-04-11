namespace LawPanel.ApiClient.Models.Helpers
{
    public class PropertyChangedDto
    {
        public string   Name                { get; set; }
        public string   HumanReadableName   { get; set; }
        public string   OriginalValue       { get; set; }
        public string   NewValue            { get; set; }
    }
}