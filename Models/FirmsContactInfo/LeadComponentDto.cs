namespace LawPanel.ApiClient.Models.FirmsContactInfo
{
    public class LeadComponentDto
    {

        public string Name { get; set; }
        public string Value { get; set; }

        public LeadComponentDto(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
