using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Firms.Watchings;

namespace LawPanel.ApiClient.Models.Watchings
{
    public class WatchingReadDto : Dto, IIdentifiableDto
    {
        public string                   Id                      { get; set; }

        public string                   UserId                  { get; set; }
        public string                   UserName                { get; set; }
        
        public int                      Sensitivity             { get; set; }
        
        public string                   FirmPortfolioId         { get; set; }
        public string                   ApplicationNumber       { get; set; }
        public string                   Trademark               { get; set; }
        public List<string>             Classes                 { get; set; }

        public string                   RegistryId              { get; set; }
        public string                   RegistryName            { get; set; }

        public string                   FrequencyId             { get; set; }
        public string                   FrequencyName           { get; set; }
        
        public List<WatchingHistoryDto> Events                  { get; set; }

        public DateTime                 Created                 { get; set; }
        public DateTime?                LastSearchDateTime      { get; set; }
        public DateTime?                LastNotificationDateTime{ get; set; }

    }
}
