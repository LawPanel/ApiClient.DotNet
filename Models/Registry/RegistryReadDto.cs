using System;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Registry
{
    public class RegistryReadDto : Dto, IIdentifiableDto
    {
        public string   Id                          { get; set; }
        public string   AlternativeNames            { get; set; }
        public string   OfficialName                { get; set; }
        public string   WipoCode                    { get; set; }
        public string   Description                 { get; set; }
        public bool     HaveData                    { get; set; }
        public bool     HaveRules                   { get; set; }
        public string   UrlBaseForTrademarks        { get; set; }
        public int      TrademarkRegistry           { get; set; }
        public string   IsoThreeLettersCountryCode  { get; set; }
        public int      TotalTrademarks             { get; set; }

        public override bool ShouldSerializeEnable() { return false; }
    }
}