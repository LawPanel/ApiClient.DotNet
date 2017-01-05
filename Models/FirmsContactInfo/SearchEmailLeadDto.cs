using System;

namespace LawPanel.ApiClient.Models.FirmsContactInfo
{
    public class SearchEmailLeadDto
    {
        public string   Email       { get; set; }
        public Guid     SearchId    { get; set; }
    }
}