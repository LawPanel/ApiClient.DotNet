using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Filters
{
    public class FilterUpdateDto : FilterCreateDto, IIdentifiableDto
    {
        public string Id { get; set; }
    }
}
