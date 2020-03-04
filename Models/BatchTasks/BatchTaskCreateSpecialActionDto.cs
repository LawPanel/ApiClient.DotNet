using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.BatchTasks
{
    public class BatchTaskCreateSpecialActionDto
    {
        public int                                  Code    { get; set; }
        public List<BatchTaskSpecialActionParamDto> Params  { get; set; }

        public BatchTaskCreateSpecialActionDto()
        {
            Params = new List<BatchTaskSpecialActionParamDto>();
        }
    }
}