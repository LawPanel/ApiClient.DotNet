using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Communications
{
    public class CommunicationMessageDto : Dto, IIdentifiableDto
    {
        public string Id        { get; set; }
        public string Subject   { get; set; }
        public string Message   { get; set; }

        public bool ShouldSerializeEnable()
        {
            return Enable = false;
        }
    }
}
