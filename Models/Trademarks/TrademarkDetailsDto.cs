using System.Collections.Generic;

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
