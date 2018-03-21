using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.Helpers.ProcessesStatus
{
    public class ProcessStatusHistory 
    {
        public long                             StartedAt       { get; set; }
        public long                             Total           { get; set; }
        public List<ProcessStatusHistoryItem>   HistoryItems    { get; set; }

        public ProcessStatusHistory()
        {
            HistoryItems = new List<ProcessStatusHistoryItem>();
        }
    }
}
