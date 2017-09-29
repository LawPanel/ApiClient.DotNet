using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Communications
{
    public class CommunicationChannelDto : Dto, IIdentifiableDto
    {
        public string Id            { get; set; }
        public string Name          { get; set; }
        public string Description   { get; set; }
    }
}
