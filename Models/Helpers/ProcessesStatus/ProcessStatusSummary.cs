namespace LawPanel.ApiClient.Models.Helpers.ProcessesStatus
{
    public class ProcessStatusSummary
    {
        public bool     IsRunning   { get; set; }
        public decimal  Percent     { get; set; }
        public int      Total       { get; set; }
        public int      Finished    { get; set; }
        public int      FinishedOk  { get; set; }
        public long     StartedAt   { get; set; }
    }
}
