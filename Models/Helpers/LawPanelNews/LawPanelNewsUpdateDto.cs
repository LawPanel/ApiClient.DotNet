using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Helpers.LawPanelNews
{
    public class LawPanelNewsUpdateDto : LawPanelNewsCreateDto, IIdentifiableDto
    {
        public string Id { get; set; }
    }
}
