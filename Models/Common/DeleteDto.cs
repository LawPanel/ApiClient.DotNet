using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Common
{
    public class DeleteDto : IIdentifiableDto
    {
        public string Id            { get; set; }
        public string EntityName    { get; set; }
    }
}
