using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Firms.FirmContactInfoes
{
    public class FirmContactInfoQualityDto : Dto, IIdentifiableDto
    {
        public string   Id          { get; set; }
        public FirmDto  Firm        { get; set; }
        public string   Name        { get; set; }
        public string   Description { get; set; }
        public bool     IsDefault   { get; set; }
        public int      Order       { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
