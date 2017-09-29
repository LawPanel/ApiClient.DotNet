using Newtonsoft.Json;

namespace LawPanel.ApiClient.Models.DataTables
{
    public class DataTablesRowData
    {
        [JsonProperty("pkey")]
        public string PrimaryKey { get; set; }
    }
}
