using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.Thirds.Markify
{
    public class Result
    {
        public string       Mark                    { get; set; }
        public string       Owners                  { get; set; }
        public string       Market                  { get; set; }
        public string       GlobalId                { get; set; }
        public string       ApplicationNumber       { get; set; }
        public string       ApplicationDate         { get; set; }
        public List<string> NiceClassification      { get; set; }
        public string       CurrentTrademarkStatus  { get; set; }
        public string       MarkFeature             { get; set; }
        public Logo         Logo                    { get; set; }
    }
}