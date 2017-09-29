using System;

namespace LawPanel.ApiClient.Models.FirmsContactInfo
{
    public class LeadComponentUpdateDto : LeadComponentDto
    {

        public Guid Id { get; set; }

        public LeadComponentUpdateDto(Guid id, string name, string value) : base(name, value)
        {
            Id = id;
        }
    }
}
