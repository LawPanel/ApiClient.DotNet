using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.TaskReminders
{
    public class TaskReminderUpdateDto : Dto, IIdentifiableDto
    {
        public string       Id              { get; set; }
        public string       Name            { get; set; }
        public DateTime     DateTime        { get; set; }
        public bool         IsSeen          { get; set; }
        public Guid         UserId          { get; set; }
        public string       Notes           { get; set; }
        public bool?        IsDeadLine      { get; set; }
        public List<Guid>   KeepInformed    { get; set; }

        public TaskReminderUpdateDto()
        {
            KeepInformed = new List<Guid>();
        }
    }
}