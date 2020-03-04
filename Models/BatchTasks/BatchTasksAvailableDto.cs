using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.BatchTasks
{
    public class BatchTasksAvailableDto
    {
        public List<BatchTaskPropertyAvailableDto>  Properties  { get; set; }
        public List<BatchTaskActionAvailableDto>    Actions     { get; set; }

        public BatchTasksAvailableDto()
        {
            Properties = new List<BatchTaskPropertyAvailableDto>();
            Actions = new List<BatchTaskActionAvailableDto>();
        }
    }
}
