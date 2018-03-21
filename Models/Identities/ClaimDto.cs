using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Identities
{
    public class ClaimDto : Dto, IIdentifiableDto
    {
        public string           Id          { get; set; }
        public ClaimTargetDto   ClaimTarget { get; set; }
        public int              Code        { get; set; }
        public string           Name        { get; set; }
        public string           Description { get; set; }
    }
}