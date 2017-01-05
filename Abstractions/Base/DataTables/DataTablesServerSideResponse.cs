using System.Collections.Generic;
using Newtonsoft.Json;

namespace LawPanel.ApiClient.Abstractions.Base.DataTables
{
    public class DataTablesServerSideResponse
    {
        [JsonProperty("draw")]
        public int                          Draw            { get; set; }
        [JsonProperty("recordsTotal")]
        public int                          RecordsTotal    { get; set; }
        [JsonProperty("recordsFiltered")]
        public int                          RecordsFiltered { get; set; }
        [JsonProperty("data")]
        public IList<object>                Data            { get; set; }


        public DataTablesServerSideResponse()
        {
            Data = new List<object>();
        }

    }
}
