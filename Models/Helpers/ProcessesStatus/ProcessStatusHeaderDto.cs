using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Helpers.ProcessesStatus
{
    public class ProcessStatusHeaderDto : IIdentifiableDto
    {
        public string   Id          { get; set; }
        public string   ProcessId   { get; set; }
        public string   FirmId      { get; set; }
        public string   UserId      { get; set; }
        public long     Total       { get; set; }
    }
}