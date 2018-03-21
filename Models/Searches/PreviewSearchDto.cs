using Newtonsoft.Json;

namespace LawPanel.ApiClient.Models.Searches
{
    public class PreviewSearchDto : Dto
    {
        public string Classes           { get; set; }
        public string Registry          { get; set; }
        public string Weighting         { get; set; }
        public string Type              { get; set; }
        public string ClassType         { get; set; }
        public string FirmSearchId      { get; set; }
    }
}