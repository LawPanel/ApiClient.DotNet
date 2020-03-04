using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LawPanel.ApiClient.Models.TaskReminders
{
    public class TaskReminderCreateDto : Dto
    {
        public Guid?        TaskReminderTemplateId  { get; set; }
        
        [Display(Name = "[[[Name]]]")]
        public string       Name                    { get; set; }

        [Display(Name = "[[[Date]]]")]
        public DateTime     DateTime                { get; set; }
        
        public Guid         TaskId                  { get; set; }
        public Guid         FileId                  { get; set; }
        public Guid         UserId                  { get; set; }
        public bool         IsSeen                  { get; set; }
        public string       Notes                   { get; set; }
        public bool?        IsDeadLine              { get; set; }
        public List<Guid>   KeepInformed            { get; set; }

        public TaskReminderCreateDto()
        {
            KeepInformed = new List<Guid>();
        }
    }
}
