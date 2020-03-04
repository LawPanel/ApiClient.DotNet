using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.BatchTasks
{
    public class BatchTaskUpdateDto : Dto, IIdentifiableDto
    {
        public string Id            { get; set; }
        public string Observations  { get; set; }
    }
}