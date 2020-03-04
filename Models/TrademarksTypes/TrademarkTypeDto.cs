using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Firms;

namespace LawPanel.ApiClient.Models.TrademarksTypes
{
    public class TrademarkTypeDto : Dto, IIdentifiableDto
    {
        public string   Id      { get; set; }
        public FirmDto  Firm    { get; set; } 
        public string   Name    { get; set; } 
        public int      Code    { get; set; }

        public TrademarkTypeDto()
        {
            Firm = new FirmDto();
        }
    }
}