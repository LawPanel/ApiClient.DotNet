using System.Linq.Expressions;

namespace LawPanel.ApiClient.Models.DataTables
{
    public class DataTablesColumnSearch
    {
        public string               Value       { get; set; }
        public bool                 Regex       { get; set; }
        public MethodCallExpression FilterWith  { get; set; }
    }
}
