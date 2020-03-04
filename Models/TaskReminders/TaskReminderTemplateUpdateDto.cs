using LawPanel.ApiClient.Interfaces;
using System;

namespace LawPanel.ApiClient.Models.TaskReminders
{
    public class TaskReminderTemplateUpdateDto : Dto, IIdentifiableDto
    {
        public string       Id          { get; set; }
        public string       Name        { get; set; }
        public int          Quantity    { get; set; } 
        public Guid         FrequencyId { get; set; }
        public string       Comparator  { get; set; }
    }
}