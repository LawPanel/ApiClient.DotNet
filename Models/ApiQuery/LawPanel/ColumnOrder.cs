using LawPanel.ApiClient.Attributes;

namespace LawPanel.ApiClient.Models.ApiQuery.LawPanel
{
    public class ColumnOrder
    {
        public string           Name        { get; set; }
        public OrderDirection   Direction   { get; set; }
    }
}
