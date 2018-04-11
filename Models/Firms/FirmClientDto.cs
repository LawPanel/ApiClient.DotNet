using System.Collections.Generic;
using LawPanel.ApiClient.Attributes;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Clients;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.Firms
{
    public class FirmClientDto : Dto, IIdentifiableDto
    {
        public string           Id                  { get; set; }

        [ApiExportable(0)]
        public ClientDto        Client              { get; set; }
        public FirmDto          Firm                { get; set; }

        public IList<UserDto>   Users               { get; set; }

        [ApiExportable(1)]
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
