using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.TaskReminders
{
    public class TaskDeadLineTypeDto : Dto, IIdentifiableDto
    {
        public string   Id    { get; set; }
        public string   Name  { get; set; }
        public int      Code  { get; set; }
    }
}
