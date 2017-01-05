using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;

namespace LawPanel.ApiClient.Models.BrandMonitoring
{
    public class BrandMonitoringConfigDto : Dto, IIdentifiableDto
    {
        public string Id        { get; set; }
        public string BrandName { get; set; }
        public string Site      { get; set; }
        
    }
}
