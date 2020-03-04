using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Reports
{
    public class ReportUpdateDto : Dto, IIdentifiableDto
    {
        public string   Id          { get; set; }
        public string   EndPoint    { get; set; }
        public string   Type        { get; set; }
        public string   Name        { get; set; }
        public string   Description { get; set; }
        public string   BlobName    { get; set; }
    }
}
