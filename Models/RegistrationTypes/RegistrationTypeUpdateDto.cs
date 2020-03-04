using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.RegistrationTypes
{
    public class RegistrationTypeUpdateDto : RegistrationTypeCreateDto, IIdentifiableDto
    {
        public string Id { get; set; }
    }
}
