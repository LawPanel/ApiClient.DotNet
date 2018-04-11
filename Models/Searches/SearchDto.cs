using System;
using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Enums;
using LawPanel.ApiClient.Interfaces;
using Newtonsoft.Json;

namespace LawPanel.ApiClient.Models.Searches
{
    public class SearchDto : Dto, IIdentifiableDto
    {
        public string               Id          { get; set; }

        [JsonProperty("search_term"), Display(Name = "[[[Query]]]")]
        public string               SearchTerm  { get; set; }
        public string               Classes     { get; set; }

        [JsonProperty("start_time"), Display(Name = "[[[Start time]]]")]
        public DateTime             StartTime   { get; set; }
        [JsonProperty("end_time"), Display(Name = "[[[End time]]]")]
        public DateTime             EndTime     { get; set; }
        public int                  Score       { get; set; }
        public string               Similarity  { get; set; }
        public string               Weightings  { get; set; }
        [Display(Name = "[[[Search type]]]")]
        public SearchType           Type        { get; set; }
        public int                  Registry    { get; set; }
        public SearchStatus         Status      { get; set; }

        [JsonProperty("status_text"), Display(Name = "[[[Status text]]]")]
        public string               StatusText  { get; set; }


        public override string ToString()
        {
            return $"Search term: {SearchTerm} / Classes: {Classes}";
        }
    }
}