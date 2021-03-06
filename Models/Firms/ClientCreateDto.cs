﻿using System.Collections.Generic;
using LawPanel.ApiClient.Models.Clients;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.Firms
{
    public class ClientCreateDto : Dto
    {
        public ClientDto            Client          { get; set; }
        public IList<UserDto>       Users           { get; set; }
        public string               ClientTypeId    { get; set; }
    }
}
