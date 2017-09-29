using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.BrandMonitoring
{
    public class BrandMonitoringCreateDto : Dto, IIdentifiableDto
    {
        public string Id { get; set; }

        [Display(Name = "[[[Brand]]]")]
        public string Brand { get; set; }

        [Display(Name = "[[[Site]]]")]
        public string Site { get; set; }

        [Display(Name = "[[[Additional comments]]]")]
        public string Comments { get; set; }
    }
}
