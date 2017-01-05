using System.Collections.Generic;
using LawPanel.ApiClient.Models.Account;

namespace LawPanel.ApiClient.Models.User
{
    public class UserLoginDetailsDto
    {
        public bool                                     IsTwoFactorAuthentication           { get; set; }
        public List<TwoFactorAuthenticationProviderDto> TwoFactorAuthenticationProviderDtos { get; set; }

        public UserLoginDetailsDto()
        {
            TwoFactorAuthenticationProviderDtos = new List<TwoFactorAuthenticationProviderDto>();   
        }
    }
}
