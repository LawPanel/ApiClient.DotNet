using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.FilesAndFolders;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.TaskReminders
{
    public class TaskReminderDto : Dto, IIdentifiableDto
    {
        public string                   Id                      { get; set; }
        public string                   Name                    { get; set; }
        public TaskReminderTemplateDto  TaskReminderTemplate    { get; set; }
        public DateTime                 DateTime                { get; set; }
        public bool                     IsSeen                  { get; set; }
        public FileDto                  File                    { get; set; }
        public UserDto                  User                    { get; set; }
        public string                   Notes                   { get; set; }
        public bool?                    IsDeadLine              { get; set; }
        public List<UserDto>            KeepInformed            { get; set; }

        public TaskReminderDto()
        {
            KeepInformed = new List<UserDto>();
        }
    }
}