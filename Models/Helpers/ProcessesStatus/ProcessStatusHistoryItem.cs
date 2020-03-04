using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.Helpers.ProcessesStatus
{
    public class ProcessStatusHistoryItem 
    {
        public string                           Status      { get; set; }
        public bool                             Success     { get; set; }
        public bool                             Finished    { get; set; }
        public List<ProcessStatusHistoryItem>   Childs      { get; set; }

        public ProcessStatusHistoryItem()
        {
            Childs = new List<ProcessStatusHistoryItem>();
        }
    }
}
