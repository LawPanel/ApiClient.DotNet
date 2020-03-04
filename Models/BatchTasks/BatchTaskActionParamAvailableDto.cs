namespace LawPanel.ApiClient.Models.BatchTasks
{
    public class BatchTaskActionParamAvailableDto
    {
        public string   Name        { get; set; }
        public string   DisplayName { get; set; }
        public string   Description { get; set; }
        public string   EndPoint    { get; set; }
        public string   Type        { get; set; }
        public bool     Multiple    { get; set; }
        public bool     Required    { get; set; }
    }
}
