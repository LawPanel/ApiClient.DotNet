using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.TrademarksTypes
{
    public class TrademarkTypeReadDto : Dto, IIdentifiableDto
    {
        public string   Id          { get; set; }
        public string   Name        { get; set; } 
        public int      Code        { get; set; }
    }
}