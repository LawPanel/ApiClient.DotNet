using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.GoodAndServices
{
    public class GaSReadDto : Dto, IIdentifiableDto
    {
        public string   Id          { get; set; }
        public int      Number      { get; set; }
        public string   Language    { get; set; }
        public string   Text        { get; set; }
    }
}
