using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.TrademarksTypes
{
    public class TrademarkTypeUpdateDto : TrademarkTypeCreateDto, IIdentifiableDto
    {
        public string Id { get; set; }
    }
}
