using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;

namespace LawPanel.ApiClient.Models.Reminders
{
    public class ReminderDto : Dto, IIdentifiableDto
    {
        public string   Id                          { get; set; }
        public long     DateTimeToSend              { get; set; }
        public string   CommunicationChannelName    { get; set; }

        public string   FromEntityType              { get; set; }
        public string   FromEntityId                { get; set; }
        public string   FromEntityDescription       { get; set; }

        public string   ToEntityType                { get; set; }
        public string   ToEntityId                  { get; set; }
        public string   ToEntityDescription         { get; set; }

        public string   EntityAssociatedId          { get; set; }
        public string   EntityAssociatedDescription { get; set; }
        public string   EntityAssociatedType        { get; set; }

        public string   Notes                       { get; set; }
    }
}