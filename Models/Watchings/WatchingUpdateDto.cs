using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Watchings
{
    public class WatchingUpdateDto : WatchingCreateDto, IIdentifiableDto
    {
        public string Id { get; set; }
    }
}
