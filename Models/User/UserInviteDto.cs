
using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Enums;

namespace LawPanel.ApiClient.Models.User
{
    public class UserInviteDto
    {
        public string               FirstName       { get; set; }
        public string               LastName        { get; set; }
        public string               Email           { get; set; }
        //Properties for FirmUser
        public List<string>           Claims          { get; set; }

        //Properties for ClientUser
        public Guid?                ClientId        { get; set; }

        public UserInviteDto()
        {
            Claims = new List<string>();
        }
    }
}
