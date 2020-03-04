using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Clients
{
    public class ClientTypeDto : Dto, IIdentifiableDto
    {
        public string   Id      { get; set; }
        public int      Code    { get; set; }
        public string   Name    { get; set; }
    }
}