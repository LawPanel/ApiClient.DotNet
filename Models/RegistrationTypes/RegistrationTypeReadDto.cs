using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.RegistrationTypes
{
    public class RegistrationTypeReadDto : Dto, IIdentifiableDto
    {
        public string   Id          { get; set; }
        public string   Name        { get; set; } 
        public int      Code        { get; set; }
    }
}