using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.Helpers.UserLinks
{
    public class UserLinkDto : Dto, IIdentifiableDto
    {
        public string   Id          { get; set; }
        public UserDto  User        { get; set; } 
        public string   Url         { get; set; } 
        public string   Comments    { get; set; }

        public UserLinkDto()
        {
            User = new UserDto();
        }
    }
}