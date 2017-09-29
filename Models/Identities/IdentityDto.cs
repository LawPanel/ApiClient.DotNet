using LawPanel.ApiClient.Models.Clients;
using LawPanel.ApiClient.Models.Firms;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.Identities
{
    public class IdentityDto : Dto
    {
        public UserDto      User    { get; set; }
        public FirmDto      Firm    { get; set; }
        public ClientDto    Client  { get; set; }
    }
}
