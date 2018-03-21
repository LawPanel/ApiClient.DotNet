namespace LawPanel.ApiClient.Models.Helpers.ProcessesStatus
{
    public class ProcessStatusRecordDto 
    {
        public string   TaskId          { get; set; }
        public string   ParentTaskId    { get; set; }
        public int      Current         { get; set; }
        public string   Status          { get; set; }
        public bool     Finished        { get; set; }
        public long     FinishedAt      { get; set; }

    }
}