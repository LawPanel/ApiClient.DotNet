using System.Collections.Generic;
using Newtonsoft.Json;

namespace LawPanel.ApiClient.Models.Templates.BootstrapTrees
{
    public class BootstrapTreeLeaf
    {
        public string                   Text            { get; set; }
        public string                   Description     { get; set; }
        public string                   Type            { get; set; }
        public string                   VarName         { get; set; }
        public string                   FullVarName     { get; set; }
        public string                   Icon            { get; set; }
        [JsonProperty("selectedIcon")]
        public string                   SelectedIcon    { get; set; }
        public string                   Color           { get; set; }
        [JsonProperty("backColor")]
        public string                   BackColor       { get; set; }
        [JsonProperty("href")]
        public string                   Href            { get; set; }
        public bool                     Selectable      { get; set; }
        public BootstrapTreeLeafState   State           { get; set; }
        public List<string>             Tags            { get; set; }
        public List<BootstrapTreeLeaf>  Nodes           { get; set; }

        public BootstrapTreeLeaf()
        {
            Nodes = new List<BootstrapTreeLeaf>();
        }
    }
}
