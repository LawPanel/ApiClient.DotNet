using Newtonsoft.Json;

namespace LawPanel.ApiClient.Models.Searches
{
    public class SearchQuery : Dto
    {
        [JsonProperty("search_term")]
        public string SearchTerm        { get; set; }
        public string Classes           { get; set; }
        public string Registry          { get; set; }
        public string Weighting         { get; set; }
        public string Type              { get; set; }
        public string ClassType         { get; set; }
        [JsonProperty("search_origin_id")]
        public string SearchOriginId    { get; set; }

        public SearchQuery()
        {
            SearchOriginId = "0";
        }
    }
}