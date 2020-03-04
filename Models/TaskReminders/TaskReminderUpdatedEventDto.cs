using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LawPanel.ApiClient.Models.TaskReminders
{
    public class TaskReminderUpdatedEventDto
    {
        public string       Id              { get; set; }
        
        [Display(Name = "[[[Name]]]")]
        public string       Name            { get; set; }
        
        [Display(Name = "[[[Date]]]")]
        public DateTime     DateTime        { get; set; }
        
        [Display(Name = "[[[Seen]]]")]
        public bool         IsSeen          { get; set; }
        
        public string       UserId          { get; set; }

        public List<Guid>   KeepInformed    { get; set; }

        public TaskReminderUpdatedEventDto()
        {
            KeepInformed = new List<Guid>();
        }
    }
}