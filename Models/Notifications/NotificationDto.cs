using LawPanel.ApiClient.Models.Communications;

namespace LawPanel.ApiClient.Models.Notifications
{
    public class NotificationDto : CommunicationRecordDto
    {
        public bool Readed  { get; set; }
        public bool Viewed  { get; set; }
    }
}