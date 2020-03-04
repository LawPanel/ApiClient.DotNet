using LawPanel.ApiClient.Attributes;
using LawPanel.ApiClient.Constants;

namespace LawPanel.ApiClient.Models.Clients
{
    [EndPoint(EndPoints.client)]
    public class ClientReadDto : ClientDto
    {
        public int TotalUsers { get; set; }
    }
}