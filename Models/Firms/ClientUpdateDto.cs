using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Firms
{
    public class ClientUpdateDto : ClientCreateDto, IIdentifiableDto
    {
        public string Id { get; set; }
    }
}
