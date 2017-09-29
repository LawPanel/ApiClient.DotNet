using Newtonsoft.Json;

namespace LawPanel.ApiClient.Models.Sales
{
    public class GoodAndServiceDto
    {
        [JsonProperty("class_number")]
        public int?     ClassNumber     { get; set; }
        public string   Description     { get; set; }
        [JsonProperty("language_code")]
        public string   LanguageCode    { get; set; }
    }
}