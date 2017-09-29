using System;
using LawPanel.ApiClient.Models.Reminders;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileReminderDto : ReminderBaseModel
    {
        public string   Id                          { get; set; }
        public Guid     FileId                      { get; set; }
        public string   CommunicationChannelName    { get; set; }
        public bool     Added                       { get; set; }
    }
}
