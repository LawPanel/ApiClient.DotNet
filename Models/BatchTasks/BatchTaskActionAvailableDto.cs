using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.BatchTasks
{
    public class BatchTaskActionAvailableDto
    {
        public int                                      Code        { get; set; }
        public string                                   Name        { get; set; }
        public string                                   Description { get; set; } 
        public List<BatchTaskActionParamAvailableDto>   Params      { get; set; }

        public BatchTaskActionAvailableDto()
        {
            Params = new List<BatchTaskActionParamAvailableDto>();
        }
    }
}