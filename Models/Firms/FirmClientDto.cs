using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Clients;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.Firms
{
    public class FirmClientDto : Dto, IIdentifiableDto
    {
        public string           Id                  { get; set; }
        public ClientDto        Client              { get; set; }
        public FirmDto          Firm                { get; set; }
        public IList<UserDto>   Users               { get; set; }
        public int              TotalUsers          { get; set; }
        public bool             IsDefaultForClient  { get; set; }


        public FirmClientDto()
        {
            Client = new ClientDto();
            Firm = new FirmDto();
            Users = new List<UserDto>();
        }
    }
}
