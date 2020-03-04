using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LawPanel.ApiClient.Models.TaskReminders
{
    public class TaskCreateDto : Dto
    {
        [Display(Name = "[[[Task name]]]")]
        public string                       Name            { get; set; }
        
        [Display(Name = "[[[Due date]]]")]
        public DateTime                     DateTimeDue     { get; set; }
        
        [Display(Name = "[[[Notes]]]")]
        public string                       Notes           { get; set; }

        public Guid                         FileId          { get; set; }
        
        public List<TaskReminderCreateDto>  TaskReminders   { get; set; }

        public TaskCreateDto()
        {
            TaskReminders = new List<TaskReminderCreateDto>();
        }
    }
}
