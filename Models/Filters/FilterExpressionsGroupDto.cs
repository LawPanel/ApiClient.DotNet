using System.Collections.Generic;
using Newtonsoft.Json;

namespace LawPanel.ApiClient.Models.Filters
{
    public class FilterExpressionsGroupDto
    {
        public List<FilterExpressionDto>    Expressions     { get; set; }

        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public string                       OperatorNext    { get; set; }
    }
}
