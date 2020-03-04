using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.TaskReminders
{
    public class TaskUpdateDto : Dto, IIdentifiableDto
    {
        public string                       Id              { get; set; }
        public string                       Name            { get; set; }
        public DateTime                     DateTimeDue     { get; set; }
        public string                       Notes           { get; set; }
        public bool                         IsSeen          { get; set; }
        public Guid                         FileId          { get; set; }
        public List<TaskReminderUpdateDto>  TaskReminders   { get; set; }
    }
}