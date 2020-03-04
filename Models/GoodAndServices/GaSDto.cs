using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Helpers;
using LawPanel.ApiClient.Models.SearchClass;

namespace LawPanel.ApiClient.Models.GoodAndServices
{
    public class GaSDto : Dto, IIdentifiableDto
    {
        public string           Id              { get; set; }
        public LanguageDto      Language        { get; set; }
        public SearchClassDto   SearchClass     { get; set; }
        public string           Text            { get; set; }
    }
}
