using System;
using LawPanel.ApiClient.Models.Reminders;

namespace LawPanel.ApiClient.Models.Firms.Portfolio
{
    public class FirmPortfolioReminderDto : ReminderBaseModel
    {
        public string   Id                          { get; set; }
        public Guid     FirmPortfolioId             { get; set; }
        public int      Days                        { get; set; }
        public string   CommunicationChannelName    { get; set; }
        public Guid     UserResponsibileForFilingId { get; set; }
        public Guid     UserResponsibileForTaskId   { get; set; }
        public bool     Added                       { get; set; }
    }
}
