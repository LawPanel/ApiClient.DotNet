using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Firms;

namespace LawPanel.ApiClient.Models.RegistrationTypes
{
    public class RegistrationTypeDto : Dto, IIdentifiableDto
    {
        public string   Id      { get; set; }
        public FirmDto  Firm    { get; set; } 
        public string   Name    { get; set; } 
        public int      Code    { get; set; }

        public RegistrationTypeDto()
        {
            Firm = new FirmDto();
        }
    }
}