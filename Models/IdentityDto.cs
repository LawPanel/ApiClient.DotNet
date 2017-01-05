using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Models.Firms;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models
{
    public class IdentityDto : Dto
    {
        public UserDto      User    { get; set; }
        public FirmDto      Firm    { get; set; }
        public ClientDto    Client  { get; set; }
    }
}
