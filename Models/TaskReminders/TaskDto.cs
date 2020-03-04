using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.FilesAndFolders;

namespace LawPanel.ApiClient.Models.TaskReminders
{
    public class TaskDto : Dto, IIdentifiableDto
    {
        public string                   Id              { get; set; }
        public string                   Name            { get; set; }
        public DateTime                 DateTimeDue     { get; set; }
        public string                   Notes           { get; set; }
        public FileDto                  File            { get; set; }
        public List<TaskReminderDto>    TaskReminders   { get; set; }
    }
}
