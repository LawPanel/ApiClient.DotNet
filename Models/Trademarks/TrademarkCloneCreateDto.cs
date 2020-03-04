using System;
using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.Trademarks
{
    public class TrademarkCloneCreateDto : Dto
    {
        public Guid       Id                { get; set; }
        public string     MarkText          { get; set; }
        public string     ApplicationNumber { get; set; }
        public List<Guid> Registries        { get; set; }

        public TrademarkCloneCreateDto()
        {
            Registries = new List<Guid>();
        }
    }
}