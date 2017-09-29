using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Tags
{
    public class TagUpdateDto : TagCreateDto, IIdentifiableDto
    {
        public string Id { get; set; }
    }
}
