using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.FilesAndFolders.FileTemplates;
using LawPanel.ApiClient.Models.Helpers;
using LawPanel.ApiClient.Models.Registry;

namespace LawPanel.ApiClient.Models.TaskReminders
{
    public class TaskDeadLineReadDto : Dto, IIdentifiableDto
    {
        public string                           Id                          { get; set; }
        public string                           Name                        { get; set; }

        public RegistryDto                      TrademarkRegistry           { get; set; }
        public FileTemplateDto                  FileTemplate                { get; set; }
        public string                           PropertyName                { get; set; }
        public string                           PropertyHumanReadableName   { get; set; }
        public TaskDeadLineTypeDto              TaskDeadLineType            { get; set; }

        public int                              Quantity                    { get; set; } 
        public FrequencyDto                     Frequency                   { get; set; }
        public string                           Comparator                  { get; set; }

        public List<TaskReminderTemplateDto>    TaskReminderTemplates       { get; set; }
    }
}