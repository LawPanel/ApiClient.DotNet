using System;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Trademarks
{
    public class TrademarkReadDto : Dto, IIdentifiableDto
    {
        public string       Id                  { get; set; }
        public string       ApplicationNumber   { get; set; }
        public DateTime?    RegistrationDate    { set; get; }
        public DateTime?    ApplicationDate     { set; get; }
        public DateTime?    ExpiryDate          { get; set; }
        public string       MarkFeature         { set; get; }
        public string       KindMark            { get; set; }
        public string       MarkText            { get; set; }
        public string       Classes             { get; set; }
        public string       Status              { get; set; }
        public string       Registry            { get; set; }
        public string       GoodAndServices     { get; set; }
        public string       Applicants          { get; set; }
        public string       Representatives     { get; set; }
        
    }
   
}