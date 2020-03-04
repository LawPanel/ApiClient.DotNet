using System.Collections.Generic;
using Newtonsoft.Json;

namespace LawPanel.ApiClient.Models.Filters
{
    public class FilterDefinitionDto 
    {
        public  List<FilterExpressionsGroupDto>     Groups          { get; set; }
        
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public  string                              OperatorNext    { get; set; }

        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public  FilterDefinitionDto                 Next            { get; set; }
    }
}