using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;
using Newtonsoft.Json;

namespace LawPanel.ApiClient.Models.Registry
{
    public class RegistryDto : Dto , IIdentifiableDto
    {
        public string   Id                              { get; set; }

        [Display(Name = "[[[Registry name]]]"), Required(ErrorMessage = "[[[Registry name is required]]]", AllowEmptyStrings = false)]
        public string   Name                            { get; set; }

        [Display(Name = "[[[Description]]]")]
        public string   Description                     { get; set; }

        [Display(Name = "[[[Registry internal code]]]"), Required(ErrorMessage = "[[[Registry code is required]]]")]
        public int      Code                            { get; set; }

        [Display(Name = "[[[URL base to show trademarks]]]")]
        public string   UrlBaseForTrademarks            { get; set; }

        public int      TrademarkRegistry               { get; set; }

        [Display(Name = "[[[We have data for this IPO]]]")]
        public bool     HaveData                        { get; set; }

        [Display(Name = "[[[We have rules for reminders for this IPO]]]")]
        public bool     HaveRules                       { get; set; }

        public string   Source                          { get; set; }

        public int      Term                            { get; set; }

        public string   FirstRenewalFrom                { get; set; }

        public string   RenewalQualifier                { get; set; }

        public int      RenewalPrePaymentPeriodOnMonths { get; set; }

        public int      GracePeriodOnMonths             { get; set; }

        public string   Penalty                         { get; set; }

        public int      SubSequentTerm                  { get; set; }

        public string   From                            { get; set; }

        public bool?    FeeForRegistration              { get; set; }

        public bool     ProofOfUseRequired              { get; set; }

        public string   Proof                           { get; set; }

        public int?     CancellationNonUseAfterYears    { get; set; }

        public string   UseRequirement                  { get; set; }

        public string   UseRequirementWhere             { get; set; }

        [JsonIgnore]
        public string   DataSources                     { get; set; }

        public string   OfficialName                    { get; set; }

        public string   WipoCode                        { get; set; }

        public override bool ShouldSerializeEnable() { return false; }

    }
}