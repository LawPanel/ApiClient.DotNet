using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.Firms
{
    public class RegisterDto : Dto
    {
        public FirmDto FirmDto { get; set; }
        public UserDto UserDto { get; set; }
    }
}
