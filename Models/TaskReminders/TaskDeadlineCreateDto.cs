using System;
using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.TaskReminders
{
    public class TaskDeadLineCreateDto : Dto
    {
        public string                                       Name                    { get; set; }
        public Guid?                                        RegistryId              { get; set; }
        public Guid?                                        FileTemplateId          { get; set; }
        public string                                       PropertyName            { get; set; }
        public int                                          Quantity                { get; set; } 
        public Guid                                         FrequencyId             { get; set; }
        public Guid                                         TaskDeadLineTypeId      { get; set; }
        public string                                       Comparator              { get; set; }     
        public ICollection<TaskReminderTemplateCreateDto>   TaskReminderTemplates   { get; set; }
        public bool?                                        CreateAsFirm            { get; set; }
    }
}