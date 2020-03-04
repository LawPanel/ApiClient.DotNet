using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.UserInputs
{
    public class UserInputUpdateDto : UserInputCreateDto, IIdentifiableDto
    {
        public string   Id          { get; set; }
    }
}
