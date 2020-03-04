using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Helpers.UserLinks
{
    public class UserLinkUpdateDto : UserLinkCreateDto, IIdentifiableDto
    {
        public string Id { get; set; }
    }
}
