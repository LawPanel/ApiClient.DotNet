using System;

namespace LawPanel.ApiClient.Models.TaskReminders
{
    public class TaskReminderTemplateCreateDto : Dto
    {
        public string       Name        { get; set; }
        public int          Quantity    { get; set; } 
        public Guid         FrequencyId { get; set; }
        public string       Comparator  { get; set; }
    }
}