using System.Collections.Generic;
using LawPanel.ApiClient.Models.Thirds.Markify;
using Newtonsoft.Json;

namespace LawPanel.ApiClient.Models.Trademarks
{
    public class TrademarkDetailsDto : TrademarkDto
    {
        public List<PriorityDto> Priorities { get; set; }

        public TrademarkDetailsDto()
        {
            Priorities = new List<PriorityDto>();
        }
        
        public override bool ShouldSerializeEnable() { return false; }
    }

}
