using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Sales
{
    public class PaymentProviderDto : Dto, IIdentifiableDto
    {
        public string   Id              { get; set; }
        public string   Name            { get; set; }
        public string   Description     { get; set; }
        public string   Url             { get; set; }
        public string   Implementation  { get; set; }
        public bool     IsDefault       { get; set; }
    }
}