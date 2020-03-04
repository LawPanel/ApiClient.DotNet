namespace LawPanel.ApiClient.Models.BatchTasks
{
    public class BatchTaskCreatePropertyDto : Dto
    {
        public string PropertyName  { get; set; }
        public string Action        { get; set; }
        public string Value         { get; set; }
    }
}