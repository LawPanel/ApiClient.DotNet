using System;
using LawPanel.ApiClient.Enums;

namespace LawPanel.ApiClient.Models.Watchings
{
    public class WatchingSearchDto
    {
        public WatchingDto              Watching    { get; set; }
        public SearchDto                Search      { get; set; }
        public DateTime                 Date        { get; set; }
        public WatchingServiceStatus    Status      { get; set; }
    }
}
