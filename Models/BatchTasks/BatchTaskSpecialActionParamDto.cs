using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.BatchTasks
{
    public class BatchTaskSpecialActionParamDto
    {
        public string       Name    { get; set; }
        public List<string> Values  { get; set; }

        public BatchTaskSpecialActionParamDto()
        {
            Values = new List<string>();
        }
    }
}
