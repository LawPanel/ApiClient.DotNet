using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.BatchTasks
{
    public class BatchTaskCreateDto : Dto
    {
        public string                                   EndPoint        { get; set; }
        public string                                   Observations    { get; set; }
        public List<BatchTaskCreatePropertyDto>         Properties      { get; set; }
        public List<BatchTaskCreateSpecialActionDto>    Actions         { get; set; }

        public BatchTaskCreateDto()
        {
            Properties = new List<BatchTaskCreatePropertyDto>();
            Actions = new List<BatchTaskCreateSpecialActionDto>();
        }
    }
}