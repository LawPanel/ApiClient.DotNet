using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.TaskReminders
{
    public class TaskDeadLineUpdateDto : Dto, IIdentifiableDto
    {
        public string                                       Id                      { get; set; }
        public string                                       Name                    { get; set; }
        public Guid?                                        RegistryId              { get; set; }
        public Guid?                                        FileTemplateId          { get; set; }
        public string                                       PropertyName            { get; set; }
        public int                                          Quantity                { get; set; } 
        public Guid                                         FrequencyId             { get; set; }
        public Guid                                         TaskDeadLineTypeId      { get; set; }
        public string                                       Comparator              { get; set; }     
        public ICollection<TaskReminderTemplateUpdateDto>   TaskReminderTemplates   { get; set; }
    }
}