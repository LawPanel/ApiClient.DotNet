using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.SearchOrigins
{
    public class SearchOriginDto : Dto,IIdentifiableDto
    {
        public string   Id          { get; set; }
        public int      Code        { get; set; }
        public string   Name        { get; set; }
        public string   Description { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
