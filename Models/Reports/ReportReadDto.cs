using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Reports
{
    public class ReportReadDto : Dto, IIdentifiableDto
    {
        public string   Id          { get; set; }
        public string   Name        { get; set; }
        public string   Type        { get; set; }
        public string   Description { get; set; }
        public string   BlobName    { get; set; } 
        public string   Dto         { get; set; } // Type of DTO containing data
        public string   Service     { get; set; } // Service name containing logic to extract data
        public bool     IsFirmOwn   { get; set; } // True means it is a personalized report
    }
}