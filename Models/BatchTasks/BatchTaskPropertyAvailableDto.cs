using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.BatchTasks
{
    public class BatchTaskPropertyAvailableDto
    {
        public string       PropertyName            { get; set; }
        public string       PropertyType            { get; set; }
        public string       PropertyDisplayName     { get; set; }
        public string       PropertyDescription     { get; set; }
        public bool         Multiple                { get; set; }
        public string       EndPoint                { get; set; }
        public bool         Required                { get; set; }
        public List<string> Actions                 { get; set; }

        public BatchTaskPropertyAvailableDto()
        {
            Actions = new List<string>();
        }
    }
}