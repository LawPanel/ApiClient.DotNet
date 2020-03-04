using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Reports
{
    public class ReportAvailableDto : IIdentifiableDto
    {
        public string   Id          { get; set; }
        public string   Name        { get; set; }
        public string   Description { get; set; }
    }
}