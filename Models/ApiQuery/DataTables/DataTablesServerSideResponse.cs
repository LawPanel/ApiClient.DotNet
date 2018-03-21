using Newtonsoft.Json;

namespace LawPanel.ApiClient.Models.ApiQuery.DataTables
{
    public class DataTablesServerSideResponse : ApiQueryResponse
    {
        [JsonProperty("draw")]
        public int                          Draw            { get; set; }

        [JsonProperty("recordsTotal")]
        public int                          RecordsTotal    { get; set; }

        [JsonProperty("recordsFiltered")]
        public int                          RecordsFiltered { get; set; }

        public DataTablesServerSideResponse() : base(true)
        {
        }
    }
}