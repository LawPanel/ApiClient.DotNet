namespace LawPanel.ApiClient.Models.Filters
{
    public class FilterCreateDto : Dto
    {
        public string               EndPoint                { get; set; } // "v1/firms/firmportfolio", "v1/firms/invoices", etc.
        public string               Name                    { get; set; }
        public bool                 ItIsLastUsedWithoutSave { get; set; } // If true should be applied by default with first user call to the endpoint api
        public bool                 Applied                 { get; set; } // If true should be applied by default with first user call to the endpoint api
        public FilterDefinitionDto  FilterDefinition        { get; set; } // FilterDefinition entity serialized. Big field.
    }
}
