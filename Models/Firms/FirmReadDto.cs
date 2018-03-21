using System;
using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.Firms
{
    public class FirmReadDto : FirmDto
    {
        public int      UsersCount          { get; set; }
        public int      ClientsCount        { get; set; }
        public string   LastLogin           { get; set; }
        public long     LastLoginUnixTime   { get; set; }
        public int      TmsOnPortfolio      { get; set; }
        public int      Searches            { get; set; }

        public List<KeyValuePair<Guid, string>> Users { get; set; }


        public FirmReadDto()
        {
            Users=new List<KeyValuePair<Guid, string>>();
        }
    }
}
