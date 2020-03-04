using System;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.BatchTasks
{
    public class BatchTaskResultDto : IIdentifiableDto
    {
        public string       Id                  { get; set; }
        public string       Action              { get; set; }
        public string       Value               { get; set; }
        public string       PropertyName        { get; set; }
        public string       PropertyType        { get; set; }
        public string       PropertyDisplayName { get; set; }
        public string       OriginalValue       { get; set; }
        public string       UpdatedValue        { get; set; }
        public DateTime?    AppliedAt           { get; set; }
    }
}
