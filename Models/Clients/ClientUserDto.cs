using LawPanel.ApiClient.Enums;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.Clients
{
    public class ClientUserDto : Dto, IIdentifiableDto
    {
        public virtual string           Id              { get; set; }
        public virtual ClientDto        Client          { get; set; }
        public virtual UserDto          User            { get; set; }
        public virtual PermissionType   PermissionType  { get; set; }
        public virtual bool             IsYoti          { get; set; }
    }
}
