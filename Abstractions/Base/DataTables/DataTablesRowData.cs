using Newtonsoft.Json;

namespace LawPanel.ApiClient.Abstractions.Base.DataTables
{
    public class DataTablesRowData
    {
        [JsonProperty("pkey")]
        public string PrimaryKey { get; set; }
    }
}
