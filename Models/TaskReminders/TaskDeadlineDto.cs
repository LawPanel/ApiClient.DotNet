using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.FilesAndFolders.FileTemplates;
using LawPanel.ApiClient.Models.Helpers;
using LawPanel.ApiClient.Models.Registry;
using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.TaskReminders
{
    public class TaskDeadLineDto : Dto, IIdentifiableDto
    {
        public string                         Id                        { get; set; }
        public string                         Name                      { get; set; }
        public string                         Comparator                { get; set; }
        public int                            Quantity                  { get; set; }
        public FrequencyDto                   Frequency                 { get; set; }
        public string                         PropertyName              { get; set; }
        public FileTemplateDto                FileTemplate              { get; set; }
        public RegistryDto                    Registry                  { get; set; }
        public TaskDeadLineTypeDto            TaskDeadLineType          { get; set; }
        public List<TaskReminderTemplateDto>  TaskReminderTemplates     { get; set; }
    }
}
