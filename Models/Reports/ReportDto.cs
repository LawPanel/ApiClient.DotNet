using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Firms;

namespace LawPanel.ApiClient.Models.Reports
{
    public class ReportDto : Dto, IIdentifiableDto
    {
        public string   Id          { get; set; }
        public FirmDto  Firm        { get; set; } // Null means this report is generic
        public string   EndPoint    { get; set; }
        public string   Type        { get; set; }
        public string   Name        { get; set; }
        public string   Description { get; set; }
        public string   BlobName    { get; set; } // Where is stored phisically this report?
        public string   Dto         { get; set; } // Type of DTO containing data
        public string   Service     { get; set; } // Service name containing logic to extract data
    }
}
