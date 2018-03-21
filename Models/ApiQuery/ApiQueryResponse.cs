using System.Collections.Generic;
using Newtonsoft.Json;

namespace LawPanel.ApiClient.Models.ApiQuery
{
    public abstract class ApiQueryResponse
    {

        public List<ApiQueryResponseHeader> Headers { get; set; }

        public readonly bool ReturnWholeObject; // Should return the whole object or only the data?

        [JsonProperty("data")]
        public IList<object> Data { get; set; } 

        protected ApiQueryResponse(bool returnWholeObject)
        {
            ReturnWholeObject = returnWholeObject;
            Data = new List<object>();
            Headers = new List<ApiQueryResponseHeader>();
        }
    }
}
