
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.BatchTasks
{
    public class BatchTaskPropertyDto : Dto, IIdentifiableDto
    {
        public string   Id              { get; set; }
        public string   PropertyName    { get; set; }
        public string   Action          { get; set; }
        public string   Value           { get; set; }
    }
}