namespace LawPanel.ApiClient.Abstractions.Base.DataTables
{
    public class DataTablesColumn
    {
        public string                   Data        { get; set; }
        public string                   Name        { get; set; }
        public bool                     Searchable  { get; set; }
        public bool                     Orderable   { get; set; }
        public DataTablesColumnSearch   Search      { get; set; }
    }
}
