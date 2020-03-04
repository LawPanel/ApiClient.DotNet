using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.TaskReminders
{
    public class TaskReadDto : Dto, IIdentifiableDto
    {
        public string                   Id              { get; set; }
        public Guid                     FileId          { get; set; }
        public string                   Name            { get; set; }
        public DateTime                 DateTimeDue     { get; set; }
        public string                   Notes           { get; set; }
        public List<TaskReminderDto>    TaskReminders   { get; set; }
    }
}