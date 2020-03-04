using System;
using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.User
{
    public class UserCreateUpdateDto : UserDto
    {
        public List<string>   ClaimsId        { get; set; }

        public UserCreateUpdateDto()
        {
            ClaimsId = new List<string>();
        }
        
    }
}
