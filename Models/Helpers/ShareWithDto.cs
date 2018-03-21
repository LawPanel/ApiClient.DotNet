using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Helpers
{
    public class ShareWithDto : Dto, IIdentifiableDto
    {
        public string Email { get; set; }
        public string Id { get; set; }
    }
}
