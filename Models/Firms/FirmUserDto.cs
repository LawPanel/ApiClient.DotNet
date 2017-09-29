using LawPanel.ApiClient.Enums;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.Firms
{
    public class FirmUserDto : Dto, IIdentifiableDto
    {
        public string           Id              { get; set; }
        public FirmDto          Firm            { get; set; }
        public UserDto          User            { get; set; }
        public PermissionType   PermissionType  { get; set; }
    }
}