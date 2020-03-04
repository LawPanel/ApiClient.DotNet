using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Helpers;

namespace LawPanel.ApiClient.Models.TaskReminders
{
    public class TaskReminderTemplateDto : Dto, IIdentifiableDto
    {
        public string       Id          { get; set; }
        public string       Name        { get; set; }
        public int          Quantity    { get; set; } 
        public FrequencyDto Frequency   { get; set; }
        public string       Comparator  { get; set; }
    }
}