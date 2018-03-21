using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Registry
{
    public class RegistryReadDto : Dto, IIdentifiableDto
    {
        public string   Id              { get; set; }
        public string   OfficialName    { get; set; }
        public string   WipoCode        { get; set; }
        public string   Description     { get; set; }
        public bool     HaveData        { get; set; }
        public bool     HaveRules       { get; set; }

        public override bool ShouldSerializeEnable() { return false; }
    }
}