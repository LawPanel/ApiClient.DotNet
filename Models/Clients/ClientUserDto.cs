using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.Clients
{
    public class ClientUserDto : Dto, IIdentifiableDto
    {
        public string     Id       { get; set; }
        public ClientDto  Client   { get; set; }
        public UserDto    User     { get; set; }
        public bool       IsYoti   { get; set; }
        public List<string> ClaimsId { get; set; }

        public ClientUserDto()
        {
            Client = new ClientDto();
            User = new UserDto();
            ClaimsId = new List<string>();
        }
    }
}
