using System.Linq.Expressions;

namespace LawPanel.ApiClient.Models.DataTables
{
    public class DataTablesColumn
    {
        public string                   Data                            { get; set; }
        public string                   Name                            { get; set; }
        public int                      Number                          { get; set; }
        public bool                     Searchable                      { get; set; }
        public bool                     Orderable                       { get; set; }
        public bool                     SearchIntoPreprocess            { get; set; }
        public ParameterExpression      SearchIntoPreprocessParameter   { get; set; } 
        public Expression               SearchIntoPreprocessExpression  { get; set; }
        public DataTablesColumnSearch   Search                          { get; set; }
    }
}
