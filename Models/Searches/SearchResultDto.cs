using System;
using Newtonsoft.Json;

namespace LawPanel.ApiClient.Models.Searches
{
    public class SearchResultDto
    {
        public string               Id                      { get; set; }
        public int                  Score                   { get; set; }
        public string               Similarity              { get; set; }
        [JsonProperty("class_match")]
        public int                  ClassMatch              { get; set; }
        [JsonProperty("application_number")]
        public string               ApplicationNumber       { get; set; }
        public string               Classes                 { get; set; }
        public string               Status                  { get; set; }
        [JsonProperty("mark_string")]
        public string               MarkString              { get; set; }
        public string               Registry                { get; set; }
        public string               RegistryOfficialName    { get; set; }
        [JsonProperty("is_registered")]
        public bool                 IsRegistered            { get; set; }
        [JsonProperty("application_date")]
        public DateTime             ApplicationDate         { get; set; }
        public string               Owner                   { get; set; }
        [JsonProperty("mark_id")]
        public int                  MarkId                  { get; set; }
    }
}