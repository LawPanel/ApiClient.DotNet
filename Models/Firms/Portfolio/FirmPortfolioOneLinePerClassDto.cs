using System;

namespace LawPanel.ApiClient.Models.Firms.Portfolio
{
    public class FirmPortfolioOneLinePerClassDto
    {
        public string       CaseReference       { get; set; }
        public string       ApplicationNumber   { get; set; }
        public string       RegistrationNumber  { get; set; }
        public string       WipoCode            { get; set; }
        public string       Country             { get; set; }
        public int          Class               { get; set; }
        public string       ClassLanguage       { get; set; }
        public string       ClassDescription    { get; set; }
        public string       MarkText            { get; set; }
        public DateTime?    ApplicationDate     { get; set; }
        public DateTime?    RegistrationDate    { get; set; }
        public DateTime?    ExpiryDate          { get; set; }
        public string       MarkOwner           { get; set; }
        public string       MarkRepresentative  { get; set; }
        public string       Status              { get; set; }
        public DateTime?    StatusDate          { get; set; }
        public DateTime?    PublicationDate     { get; set; }
        public string       Notes               { get; set; }
    }
}