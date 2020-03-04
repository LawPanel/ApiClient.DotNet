using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Helpers.LawPanelNewsType
{
    public class LawPanelNewsTypeUpdateDto : LawPanelNewsTypeCreateDto, IIdentifiableDto
    {
        public string Id { get; set; }
    }
}
