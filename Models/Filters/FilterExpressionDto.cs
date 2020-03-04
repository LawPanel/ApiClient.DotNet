using Newtonsoft.Json;

namespace LawPanel.ApiClient.Models.Filters
{
    public class FilterExpressionDto 
    {
        public string   PropertyName    { get; set; }
        public string   Comparator      { get; set; }
        public string   Value           { get; set; }
        public bool     Personalized    { get; set; }

        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public string   OperatorNext    { get; set; }
    }
}